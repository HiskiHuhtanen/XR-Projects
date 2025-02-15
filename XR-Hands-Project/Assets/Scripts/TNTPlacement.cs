using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TNTPlacement : MonoBehaviour
{
    public GameObject snapPosition; // The exact position where TNT will snap
    private bool isOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOccupied && other.CompareTag("TNT"))
        {
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
            if (grab && !grab.isSelected)
            {
                SnapToPlace(other.gameObject);
            }
        }
    }

    private void SnapToPlace(GameObject tnt)
    {
        tnt.transform.position = snapPosition.transform.position;
        tnt.transform.rotation = snapPosition.transform.rotation;
        Rigidbody rb = tnt.GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true; // Disable physics
        isOccupied = true;
    }
}
