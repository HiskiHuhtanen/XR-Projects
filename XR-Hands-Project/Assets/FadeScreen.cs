using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public GameObject fadeQuad; // Assign a Quad or UI Panel for fading
    public float fadeDuration = 1.5f;
    public string nextSceneName;

    private Material fadeMaterial;
    private bool isFading = false;

    void Start()
    {
        if (fadeQuad != null)
        {
            Renderer renderer = fadeQuad.GetComponent<Renderer>();
            if (renderer != null)
            {
                fadeMaterial = renderer.material;
                Color startColor = fadeMaterial.color;
                startColor.a = 0;
                fadeMaterial.color = startColor;

                Debug.Log("FadeAndLoad: Fade Quad initialized.");
            }
            else
            {
                Debug.LogError("FadeAndLoad: FadeQuad has no Renderer! Assign a Quad with a Material.");
            }
        }
        else
        {
            Debug.LogError("FadeAndLoad: FadeQuad is not assigned in the inspector!");
        }
    }

    public void StartFade()
    {
        if (!isFading)
        {
            Debug.Log("FadeAndLoad: StartFade() called.");
            StartCoroutine(FadeInAndLoad());
        }
        else
        {
            Debug.LogWarning("FadeAndLoad: Fade already in progress.");
        }
    }

    private IEnumerator FadeInAndLoad()
    {
        isFading = true;
        float timer = 0f;

        if (fadeMaterial == null)
        {
            Debug.LogError("FadeAndLoad: Fade Material is missing!");
            yield break;
        }

        Color color = fadeMaterial.color;

        Debug.Log("FadeAndLoad: Fading in...");

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeMaterial.color = color;
            yield return null;
        }

        color.a = 1;
        fadeMaterial.color = color;

        Debug.Log($"FadeAndLoad: Loading scene '{nextSceneName}'");
        SceneManager.LoadScene(nextSceneName);
    }
}
