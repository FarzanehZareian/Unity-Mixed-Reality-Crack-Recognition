using UnityEngine;

public class RuntimeConfig : MonoBehaviour
{
    public enum RunMode
    {
        OfflineImage,
        OfflineVideo,
        HoloLensLive
    }

    [Header("Runtime Mode")]
    public RunMode currentMode = RunMode.OfflineVideo;

    [Header("Offline Components")]
    public GameObject imageTestFeeder;
    public GameObject videoTestFeeder;
    public GameObject diagnosticCanvas;

    [Header("Live Components")]
    public Camera mainCamera; // MRTK camera
    public bool enableMRTKCamera = true;

    void Awake()
    {
        ApplyMode();
    }

    void ApplyMode()
    {
        // Disable everything first
        if (imageTestFeeder != null) imageTestFeeder.SetActive(false);
        if (videoTestFeeder != null) videoTestFeeder.SetActive(false);
        if (diagnosticCanvas != null) diagnosticCanvas.SetActive(false);

        Debug.Log($"RuntimeConfig: MODE = {currentMode}");

        switch (currentMode)
        {
            case RunMode.OfflineImage:
                if (imageTestFeeder != null) imageTestFeeder.SetActive(true);
                if (diagnosticCanvas != null) diagnosticCanvas.SetActive(true);
                break;

            case RunMode.OfflineVideo:
                if (videoTestFeeder != null) videoTestFeeder.SetActive(true);
                if (diagnosticCanvas != null) diagnosticCanvas.SetActive(true);
                break;

            case RunMode.HoloLensLive:
                // MRTK camera feeds pipeline automatically
                if (mainCamera != null && enableMRTKCamera)
                    mainCamera.enabled = true;
                break;
        }
    }
}
