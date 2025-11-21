
using UnityEngine;

public class WebcamRenderer : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private Renderer objectRenderer;

    void Start()
    {
        // Check for webcam devices
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogError("No webcam devices found.");
            return;
        }

        // Get the default webcam
        WebCamDevice device = WebCamTexture.devices[0];
        webcamTexture = new WebCamTexture(device.name);

        // Get the Renderer component of this GameObject
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer component found on this GameObject.");
            return;
        }

        // Set the webcam texture to the material
        objectRenderer.material.mainTexture = webcamTexture;

        // Start the webcam
        webcamTexture.Play();
    }

    void OnDestroy()
    {
        // Stop the webcam when the object is destroyed
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
}
