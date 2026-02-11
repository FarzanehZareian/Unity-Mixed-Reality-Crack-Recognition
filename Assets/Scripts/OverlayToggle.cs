using UnityEngine;

public class OverlayToggle : MonoBehaviour
{
    [Header("Overlay")]
    public GameObject overlayView;

    [Header("Optional UI")]
    public GameObject classificationLabel;

    public void ToggleOverlay()
    {
        if (overlayView == null)
        {
            Debug.LogWarning("OverlayToggle: overlayView not assigned");
            return;
        }

        bool isOn = overlayView.activeSelf;
        overlayView.SetActive(!isOn);

        // OPTIONAL: hide UI together
        if (classificationLabel != null)
            classificationLabel.SetActive(!isOn);
   
    }
}
