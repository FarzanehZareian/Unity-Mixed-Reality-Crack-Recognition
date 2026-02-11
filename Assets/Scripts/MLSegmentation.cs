// ======================================================
// MLSegmentation (DEPLOYMENT-READY)
// TASK: Crack segmentation + uncertainty estimation
// MODEL: masonry_segmentation_v1.onnx
// ======================================================

using UnityEngine;
using Unity.Barracuda;

public class MLSegmentation : MonoBehaviour
{
    [Header("Model")]
    public NNModel segmentationModel;

    [Header("Input")]
    public RenderTexture inputTexture;

    [Header("Output")]
    public RenderTexture maskTexture;

    [Header("Uncertainty Output")]
    public RenderTexture uncertaintyTexture;

    [Header("Settings")]
    public int imageSize = 224;

    [Range(0.1f, 1.0f)]
    public float inferenceInterval = 0.25f;

    [Header("Light Morphology")]
    public bool enableMorphology = true;
    public Material blurMaterial;
    public Material dilateMaterial;

    [Header("Uncertainty")]
    public Material uncertaintyMaterial;

    private Model runtimeModel;
    private IWorker worker;
    private Texture2D inputTexture2D;
    private float inferenceTimer;

    // ======================================================
    void Start()
    {
        runtimeModel = ModelLoader.Load(segmentationModel);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, runtimeModel);

        inputTexture2D = new Texture2D(
            imageSize,
            imageSize,
            TextureFormat.RGB24,
            false
        );

        if (maskTexture == null)
        {
            maskTexture = CreateRT(RenderTextureFormat.RFloat);
        }

        if (uncertaintyTexture == null)
        {
            uncertaintyTexture = CreateRT(RenderTextureFormat.RFloat);
        }

        ClearTextures();
    }

    void Update()
    {
        inferenceTimer += Time.deltaTime;
        if (inferenceTimer >= inferenceInterval)
        {
            inferenceTimer = 0f;
            RunSegmentation();
        }
    }

    // ======================================================
    void RunSegmentation()
    {
        if (inputTexture == null || worker == null)
            return;

        RenderTexture.active = inputTexture;
        inputTexture2D.ReadPixels(
            new Rect(0, 0, imageSize, imageSize),
            0, 0
        );
        inputTexture2D.Apply();
        RenderTexture.active = null;

        using (Tensor input = new Tensor(inputTexture2D, 3))
        {
            worker.Execute(input);

            using (Tensor output = worker.PeekOutput())
            {
                // Raw probability mask
                output.ToRenderTexture(maskTexture);
            }
        }

        // Uncertainty from raw probabilities
        ComputeUncertainty();

        // Optional morphology for visualization
        if (enableMorphology)
            ApplyLightMorphology();
    }

    // ======================================================
    void ApplyLightMorphology()
    {
        RenderTexture temp = RenderTexture.GetTemporary(
            imageSize, imageSize, 0, RenderTextureFormat.RFloat
        );

        if (blurMaterial != null)
        {
            blurMaterial.SetFloat("_TexelSize", 1.0f / imageSize);
            Graphics.Blit(maskTexture, temp, blurMaterial);
            Graphics.Blit(temp, maskTexture);
        }

        if (dilateMaterial != null)
        {
            dilateMaterial.SetFloat("_TexelSize", 1.0f / imageSize);
            Graphics.Blit(maskTexture, temp, dilateMaterial);
            Graphics.Blit(temp, maskTexture);
        }

        RenderTexture.ReleaseTemporary(temp);
    }

    // ======================================================
    void ComputeUncertainty()
    {
        if (uncertaintyMaterial == null || uncertaintyTexture == null)
            return;

        Graphics.Blit(maskTexture, uncertaintyTexture, uncertaintyMaterial);
    }

    // ======================================================
    RenderTexture CreateRT(RenderTextureFormat format)
    {
        RenderTexture rt = new RenderTexture(imageSize, imageSize, 0, format);
        rt.enableRandomWrite = true;
        rt.Create();
        return rt;
    }

    void ClearTextures()
    {
        RenderTexture active = RenderTexture.active;

        RenderTexture.active = maskTexture;
        GL.Clear(false, true, Color.black);

        RenderTexture.active = uncertaintyTexture;
        GL.Clear(false, true, Color.black);

        RenderTexture.active = active;
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
