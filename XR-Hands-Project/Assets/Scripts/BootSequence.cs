using System.Collections;
using TMPro;
using UnityEngine;

public class BootSequence : MonoBehaviour
{
    public TextMeshProUGUI bootText;  // Assign in Inspector
    public float typingSpeed = 0.05f;
    public GameObject blackoutScreen; // Assign Quad or use Camera fade

    private string[] bootMessages = new string[]
    {
        "System Starting...\n",
        "Version 1.3.5\n",
        "Checking System Integrity...\n",
        "Warning: Data Corruption Detected\n",
        "Reconstructing Data...\n",
        "New Protocols Detected: None\n",
        "Attempting Connection...\n",
        "Error: No Response\n",
        "Initializing Basic Functions...\n"
    };

    void Start()
    {
        StartCoroutine(StartBootSequence());
    }

    IEnumerator StartBootSequence()
    {
        yield return new WaitForSeconds(1f); // Wait before starting

        bootText.text = "";
        foreach (string message in bootMessages)
        {
            yield return StartCoroutine(TypeText(message));
            yield return new WaitForSeconds(1f);
        }

        // Fade out the text
        yield return StartCoroutine(FadeTextOut());

        // Fade the black screen to clear vision
        if (blackoutScreen != null)
        {
            yield return StartCoroutine(FadeToClear());
        }
    }

    IEnumerator TypeText(string message)
    {
        foreach (char letter in message)
        {
            bootText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator FadeTextOut()
    {
        TextMeshProUGUI text = bootText;
        Color originalColor = text.color;

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - t);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    IEnumerator FadeToClear()
    {
        MeshRenderer screenRenderer = blackoutScreen.GetComponent<MeshRenderer>();
        Color originalColor = screenRenderer.material.color;

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            screenRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - t);
            yield return null;
        }

        blackoutScreen.SetActive(false); // Hide after fade
    }
}
