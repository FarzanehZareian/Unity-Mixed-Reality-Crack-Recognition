using UnityEngine;
using Unity.Barracuda;
using TMPro;
using System.Collections.Generic;

public class MLClassification : MonoBehaviour
{
    [Header("Model")]
    public NNModel modelAsset;

    [Header("Input")]
    public RenderTexture inputTexture;

    [Header("UI")]
    public TextMeshProUGUI resultTMP;

    [Header("Inference Settings")]
    [Tooltip("Frames used for temporal smoothing")]
    public int smoothingWindow = 10;

    [Tooltip("Inference interval in seconds")]
    public float inferenceInterval = 0.2f;

    private Model runtimeModel;
    private IWorker worker;
    private Texture2D inputTexture2D;

    private float timer;
    private Queue<float> history = new Queue<float>();

    void Start()
    {
        runtimeModel = ModelLoader.Load(modelAsset);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, runtimeModel);

        inputTexture2D = new Texture2D(
            inputTexture.width,
            inputTexture.height,
            TextureFormat.RGB24,
            false
        );
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= inferenceInterval)
        {
            timer = 0f;
            RunInference();
        }
    }

    void RunInference()
    {
        RenderTexture.active = inputTexture;
        inputTexture2D.ReadPixels(
            new Rect(0, 0, inputTexture.width, inputTexture.height),
            0, 0
        );
        inputTexture2D.Apply();
        RenderTexture.active = null;

        using (var tensor = new Tensor(inputTexture2D, 3))
        {
            worker.Execute(tensor);
            float raw = worker.PeekOutput()[0];

            history.Enqueue(raw);
            if (history.Count > smoothingWindow)
                history.Dequeue();

            float avg = 0f;
            foreach (var v in history) avg += v;
            avg /= history.Count;

            string label = avg >= 0.5f
                ? "Brick Crack"
                : "Mortar Crack";

            if (resultTMP != null)
            {
                resultTMP.text =
                    $"<b>{label}</b>\nConfidence: {avg:0.00}";
            }
        }
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
