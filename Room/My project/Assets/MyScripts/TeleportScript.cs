using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportScript : MonoBehaviour
{

    public InputActionReference action;
    public Transform inside;
    public Transform outside;
    private bool insideRoom = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (insideRoom)
            {
                transform.position =  outside.position;
            }
            else
            {
                transform.position = inside.position;
            }
            insideRoom = !insideRoom;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
