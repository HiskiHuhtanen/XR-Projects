using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class VRButton : MonoBehaviour
{

    //Time that the button is set inactive after release
    public float deadTime = 1.0f;
    //Bool used to lock down button during its set dead time
    private bool _deadTimeActivate = false;

    //public unity Events we can use in the editor and tie other functions to
    public UnityEvent onPressed, onReleased;

    //Checks if the current collider entering is the button adn sets off OnPressed event
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActivate)
        {
            onPressed?.Invoke();
        }
    }


    //Checks if the current collider entering is the button adn sets off OnPressed event
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActivate)
        {
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
