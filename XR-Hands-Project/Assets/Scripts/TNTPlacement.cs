using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TNTPlacement : MonoBehaviour
{
    public GameObject snapPosition;
    public GameObject wireObject;

    private static int tntCount = 0;
    private static int totalTNT = 3;

    public static TNTPlacement[] placements;
    public static GameObject exploder;

    private bool isOccupied = false;

    private void Start()
    {
        if (exploder == null)
            exploder = GameObject.FindWithTag("Button");

        if (exploder != null)
        {
            SetExploderCollidersState(false);
        }
    }

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
        if (rb) rb.isKinematic = true;

        isOccupied = true;
        tntCount++;

        if (wireObject != null)
        {
            wireObject.layer = LayerMask.NameToLayer("Default");
        }

        if (tntCount >= totalTNT)
        {
            ActivateExploder();
        }
    }

    private static void ActivateExploder()
    {
        if (exploder != null)
        {
            SetExploderCollidersState(true);
        }
    }

    private static void SetExploderCollidersState(bool state)
    {
        if (exploder != null)
        {
            foreach (Collider col in exploder.GetComponents<Collider>())
            {
                col.enabled = state;
            }
        }
    }
}
