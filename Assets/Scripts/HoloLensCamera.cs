using UnityEngine;
using UnityEngine.Windows.WebCam;

public class HoloLensCamera : MonoBehaviour
{
    PhotoCapture photoCapture;

    void Start()
    {
        PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
    }

    void OnPhotoCaptureCreated(PhotoCapture capture)
    {
        photoCapture = capture;
        CameraParameters camParams = new CameraParameters();
        camParams.cameraResolutionWidth = 896;
        camParams.cameraResolutionHeight = 504;
        camParams.pixelFormat = CapturePixelFormat.BGRA32;

        photoCapture.StartPhotoModeAsync(camParams, OnPhotoModeStarted);
    }

    void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
    {
        photoCapture.TakePhotoAsync(OnCapturedPhoto);
    }

    void OnCapturedPhoto(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame frame)
    {
        Texture2D tex = new Texture2D(896, 504, TextureFormat.BGRA32, false);
        frame.UploadImageDataToTexture(tex);

        // Send this texture to inference
    }
}
