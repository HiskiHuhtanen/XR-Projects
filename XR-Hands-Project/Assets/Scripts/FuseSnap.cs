using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FuseSnap : MonoBehaviour
{
    public Transform snapPoint;  // Assign this to the transform of the snap location
    public GameObject button;    // The button that becomes functional
    public Light fuseBoxLight;   // Assign the light in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable fuse = other.GetComponent<XRGrabInteractable>();

        if (fuse != null) // Ensure it's an interactable object
        {
            // Disable interaction so it stays locked
            fuse.enabled = false;

            // Snap fuse to the correct position
            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;
            other.transform.SetParent(snapPoint);  // Make it a child to stay locked in place

            // Change light color to green
            if (fuseBoxLight != null)
            {
                fuseBoxLight.color = Color.green;
            }

            // Activate the button
            button.GetComponent<ButtonInteractable>().ActivateButton();
        }
    }
}
