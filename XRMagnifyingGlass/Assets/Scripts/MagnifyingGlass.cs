using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public Camera magnifyingCamera;    // Camera used for magnification (render texture)
    public Transform magnifyingGlass;  // Transform of the magnifying glass
    public Transform playerHead;       // The player's head (Camera.main.transform)
    public float magnificationFactor = 2.0f; // Amount of magnification (zoom level)

    void Update()
    {
        // Position the magnifying camera at the lens's position
        magnifyingCamera.transform.position = magnifyingGlass.position;

        // Lock the magnifying glass's rotation on the Z-axis
        Vector3 currentRotation = magnifyingGlass.eulerAngles;
        magnifyingGlass.eulerAngles = new Vector3(currentRotation.x, currentRotation.y, 0);

        // Calculate the direction the camera should always look in (direction the player is looking)
        Vector3 directionToLook = playerHead.forward;

        // Align the magnifying camera to face the player's view (but don't rotate with the lens)
        magnifyingCamera.transform.rotation = Quaternion.LookRotation(directionToLook);

        // Adjust the camera's field of view to simulate magnification (zoom in)
        magnifyingCamera.fieldOfView = 60 / magnificationFactor; // Adjust for desired zoom level

        // Optional: Use a specific layer to only render objects visible through the magnifying lens
       // magnifyingCamera.cullingMask = LayerMask.GetMask("MagnifiedObjects");
    }
}
