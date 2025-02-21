using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool _deadTimeActivate = false;

    public UnityEvent onPressed, onReleased;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActivate)
        {
            Debug.Log("VRButton: Button Pressed!");
            onPressed?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && !_deadTimeActivate)
        {
            Debug.Log("VRButton: Button Released!");
            onReleased?.Invoke();
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActivate = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActivate = false;
    }
}
