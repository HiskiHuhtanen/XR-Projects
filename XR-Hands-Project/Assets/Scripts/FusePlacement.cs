using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FusePlacement : MonoBehaviour
{
    public GameObject snapPosition;
    private bool isOccupied = false;

    private static int fuseCount = 0;
    private static int requiredFuses = 4;
    public Light indicatorLight;
    public GameObject door;
    public float doorMoveSpeed = 2f;
    public float doorMoveDistance = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (!isOccupied && other.CompareTag("FUSE"))
        {
            XRGrabInteractable grab = other.GetComponent<XRGrabInteractable>();
            if (grab && !grab.isSelected)
            {
                SnapToPlace(other.gameObject);
                fuseCount++;
            }
        }
    }

    private void SnapToPlace(GameObject fuse)
    {
        fuse.transform.position = snapPosition.transform.position;
        fuse.transform.rotation = snapPosition.transform.rotation;
        Rigidbody rb = fuse.GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true; // Disable physics

        isOccupied = true;
        fuseCount++;

        if (fuseCount >= requiredFuses)
        {
            ActivateEvent();
        }
    }

    private void ActivateEvent()
    {
        if (indicatorLight != null)
        {
            indicatorLight.color = Color.green;
        }

        if (door != null)
        {
            StartCoroutine(MoveDoorDown());
        }
    }

    private IEnumerator MoveDoorDown()
    {
        Vector3 startPos = door.transform.position;
        Vector3 targetPos = startPos + Vector3.down * doorMoveDistance;

        float elapsedTime = 0f;
        while (elapsedTime < doorMoveDistance / doorMoveSpeed)
        {
            door.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / (doorMoveDistance / doorMoveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        door.transform.position = targetPos;
    }
}
