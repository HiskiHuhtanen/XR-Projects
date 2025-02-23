using UnityEngine;

public class RemoveTempLayer : MonoBehaviour
{
    public Camera mainCamera;
    public string tempLayerName = "Temp";
    private int tempLayerMask;

    void Start()
    {
        // Get the layer mask for the "Temp" layer
        tempLayerMask = LayerMask.NameToLayer(tempLayerName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            mainCamera.cullingMask &= ~(1 << tempLayerMask);
        }
    }
}
