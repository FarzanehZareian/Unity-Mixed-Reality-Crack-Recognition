using UnityEngine;
using UnityEngine.UI;

public class TestImageFeeder : MonoBehaviour
{
    public Texture2D[] testImages;
    public RenderTexture targetRT;

    [Range(0.1f, 3f)]
    public float imageSwitchInterval = 1.5f;

    private int index = 0;
    private float timer = 0f;

    void Update()
    {
        if (testImages.Length == 0 || targetRT == null)
            return;

        timer += Time.deltaTime;

        if (timer >= imageSwitchInterval)
        {
            timer = 0f;
            index = (index + 1) % testImages.Length;

            Graphics.Blit(testImages[index], targetRT);
        }
    }
}
