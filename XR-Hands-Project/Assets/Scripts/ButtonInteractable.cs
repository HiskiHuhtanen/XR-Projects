using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ButtonInteractable : MonoBehaviour
{
    public UnityEvent onButtonActivated;  
    public Transform slidingDoor;
    public float moveDistance = 2f;
    public float moveSpeed = 2f;

    private bool isActive = false;
    private bool doorOpened = false;

    public void ActivateButton()
    {
        isActive = true;
        Debug.Log("Button is now active!");
    }

    public void PressButton()
    {
        if (isActive && !doorOpened)
        {
            Debug.Log("Button Pressed! Opening Door...");
            StartCoroutine(MoveDoorDown());
            doorOpened = true;
            onButtonActivated.Invoke();
        }
        else
        {
            Debug.Log("Button is inactive or door is already opened.");
        }
    }

    private IEnumerator MoveDoorDown()
    {
        Vector3 startPosition = slidingDoor.position;
        Vector3 targetPosition = startPosition + Vector3.down * moveDistance;

        float elapsedTime = 0;
        while (elapsedTime < (moveDistance / moveSpeed))
        {
            slidingDoor.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / (moveDistance / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        slidingDoor.position = targetPosition;
    }
}
