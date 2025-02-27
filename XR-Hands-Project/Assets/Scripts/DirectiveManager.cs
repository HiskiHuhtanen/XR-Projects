using UnityEngine;
using TMPro;
using System.Collections;

public class DirectiveManager : MonoBehaviour
{
    public TextMeshProUGUI directiveText;
    public AudioClip soundEffect;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(ShowFirstDirective());
    }

    IEnumerator ShowFirstDirective()
    {
        yield return new WaitForSeconds(2);
        directiveText.text = "Directive: Return to Charging Station";
        yield return new WaitForSeconds(2); 
        directiveText.text = "";
        audioSource.PlayOneShot(soundEffect);
        yield return new WaitForSeconds(soundEffect.length);
        directiveText.text = "Directive: Break the Seal";
        yield return new WaitForSeconds(4);
        directiveText.text = "";
    }
}
