using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRDaggerInteraction : MonoBehaviour
{
    public Camera mainCamera; // Assign the main camera
    public LayerMask overworldLayer; // Assign the Overworld layer mask
    public LayerMask voidLayer; // Assign the Void layer mask

    private XRGrabInteractable grabInteractable;
    private AudioSource audioSource;

    void Start()
    {
    // Code to run after Awake, but before the first frame update.
    }
    
    void Awake()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Subscribe to the grab and release events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Play the pickup sound
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Switch the camera to render only the Void layer
        if (mainCamera != null)
        {
            mainCamera.cullingMask = voidLayer;
        }

    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Revert the camera to render only the Overworld layer
        if (mainCamera != null)
        {
            mainCamera.cullingMask = overworldLayer;
        }

    }
}
