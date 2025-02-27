using UnityEngine;

public class VisionBlockerTrigger : MonoBehaviour
{

    public GameObject quad;

    private Material quadMaterial;
    public string hiddenLayerName = "Hidden";
    public string defaultLayerName = "Default";
    public float alphaIncreaseAmount = 0.2f;
    public float maxAlpha = 1f;
    private float currentAlpha = 0f;

    private void Start()
    {
        if (quad != null)
        {
            quadMaterial = quad.GetComponent<Renderer>().material;
            quad.layer = LayerMask.NameToLayer(hiddenLayerName);
            currentAlpha = 0f;
            SetQuadAlpha(currentAlpha); 
        }
        else
        {
            Debug.LogError("You didnt assing it!!!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            IncreaseOpacity();
        }
    }

    private void IncreaseOpacity()
    {
        currentAlpha = Mathf.Min(currentAlpha + alphaIncreaseAmount, maxAlpha);
        SetQuadAlpha(currentAlpha);
        if (currentAlpha > 0)
        {
            quad.layer = LayerMask.NameToLayer(defaultLayerName);
        }
    }

    private void SetQuadAlpha(float alpha)
    {
        if (quadMaterial != null)
        {
            Color currentColor = quadMaterial.color;
            currentColor.a = alpha;
            quadMaterial.color = currentColor;
        }
    }
}
