using UnityEngine;

public class OverlayComposer : MonoBehaviour
{
    public RenderTexture inputRT;
    public RenderTexture maskRT;
    public RenderTexture outputRT;
    public Material overlayMaterial;

    void Update()
    {
        if (inputRT == null || maskRT == null || outputRT == null || overlayMaterial == null)
            return;

        overlayMaterial.SetTexture("_MainTex", inputRT);
        overlayMaterial.SetTexture("_MaskTex", maskRT);

        Graphics.Blit(inputRT, outputRT, overlayMaterial);
    }
}
