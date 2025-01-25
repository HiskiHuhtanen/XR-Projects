using UnityEngine;
using UnityEngine.InputSystem;
public class LightScript : MonoBehaviour
{

    public InputActionReference action;
    private Light pointLight;
    private bool red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointLight = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (red)
            {
                pointLight.color = Color.white;
            }
            else
            {
                pointLight.color = Color.red;
            }
            red = !red;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
