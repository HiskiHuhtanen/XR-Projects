using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    [Header("Fade Settings")]
    public GameObject fadeQuad; 
    public float fadeDuration = 1.5f;
    public float waitBeforeFade = 2f;

    [Header("UI Settings")]
    public TextMeshProUGUI directiveText; 
    public float typingSpeed = 0.05f;
    public string[] directives;

    [Header("Scene Settings")]
    public string nextSceneName;
    public AudioSource fadeInSound;
    public AudioSource fadeOutSound;

    private Material fadeMaterial;
    private int hiddenLayer;

    void Start()
    {
        if (fadeQuad != null)
        {
            Renderer renderer = fadeQuad.GetComponent<Renderer>();
            if (renderer != null)
            {
                fadeMaterial = renderer.material;
                fadeMaterial.color = new Color(0, 0, 0, 1);
                hiddenLayer = LayerMask.NameToLayer("Hidden"); 
                StartCoroutine(ArrivalSequence());
            }
            else
            {
                Debug.LogError("FadeQuad has no Renderer!");
            }
        }
        else
        {
            Debug.LogError("FadeQuad is not assigned!");
        }
    }

    IEnumerator ArrivalSequence()
    {
        Debug.Log("Scene started, waiting before fade-in...");
        yield return new WaitForSeconds(waitBeforeFade);

        if (fadeInSound != null)
        {
            fadeInSound.Play();
        }
        else
        {
            Debug.LogWarning("No fade-in sound assigned!");
        }

        yield return StartCoroutine(FadeFromBlack());

        StartCoroutine(DisplayDirectives());
    }

    IEnumerator FadeFromBlack()
    {
        Debug.Log("Fading in...");
        float timer = 0f;
        Color color = fadeMaterial.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, timer / fadeDuration);
            fadeMaterial.color = color;
            yield return null;
        }

        fadeMaterial.color = new Color(0, 0, 0, 0); // Fully transparent
        fadeQuad.layer = hiddenLayer; // Move to Hidden layer
        Debug.Log("FadeQuad moved to Hidden layer.");
    }

    IEnumerator DisplayDirectives()
    {
        yield return new WaitForSeconds(1);

        foreach (string directive in directives)
        {
            yield return StartCoroutine(TypeText(directive));
            yield return new WaitForSeconds(5);
            directiveText.text = "";
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator TypeText(string message)
    {
        directiveText.text = "";
        foreach (char letter in message)
        {
            directiveText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartFadeOut()
    {
        Debug.Log("Fading out...");
        StartCoroutine(FadeToBlackAndLoad());
    }

    IEnumerator FadeToBlackAndLoad()
    {
        if (fadeOutSound != null)
        {
            fadeOutSound.Play();
        }
        else
        {
            Debug.LogWarning("No fade-out sound assigned!");
        }

        float timer = 0f;
        Color color = fadeMaterial.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeMaterial.color = color;
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
