using UnityEngine;
using TMPro;
using System.Collections;

public class FinalTrigger : MonoBehaviour
{
    public GameObject fadeQuad; // The quad for the black screen
    public TextMeshProUGUI endText; // The TextMeshPro component for "Connection Lost"
    public string hiddenLayerName = "Hidden";
    public string defaultLayerName = "Default";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            // Change the quad layer to default
            fadeQuad.layer = LayerMask.NameToLayer(defaultLayerName);

            // Start the text reveal
            StartCoroutine(ShowEndText());
        }
    }

    private IEnumerator ShowEndText()
    {
        string finalMessage = "Connection Lost";

        // Reveal each letter with a slight delay
        for (int i = 0; i <= finalMessage.Length; i++)
        {
            endText.text = finalMessage.Substring(0, i);
            yield return new WaitForSeconds(0.1f); // Adjust time between letters as needed
        }
    }
}
