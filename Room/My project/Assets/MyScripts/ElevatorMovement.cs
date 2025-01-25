using System.Collections;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public Transform targetPositionUp;
    public Transform targetPositionDown; 
    public float speed = 2f;
    private bool isGoingUp = true;
    private bool isMoving = false;

    void Start()
    {
        transform.position = targetPositionDown.position;
    }

    public void ToggleElevator()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveElevator());
        }
    }

    IEnumerator MoveElevator()
    {
        isMoving = true;

        Vector3 targetPosition = isGoingUp ? targetPositionUp.position : targetPositionDown.position;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isGoingUp = !isGoingUp;
        isMoving = false;
    }
}
