using UnityEngine;
using TMPro;
using System.Collections;

public class DirectiveTrigger : MonoBehaviour
{
    public TextMeshProUGUI directiveText;
    public string newDirective = "Directive: Continue";
    public float displayTime = 5f;
    public Color glitchColor = new Color(1f, 0f, 1f);
    public AudioSource glitchSound;
    public float typingSpeed = 0.05f;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {   //Wonder why Unity didn't let me make a "Player" tag
        if (other.CompareTag("PLAYER") && !triggered)
        {
            triggered = true;
            StartCoroutine(DisplayGlitchDirective());
        }
    }

    IEnumerator DisplayGlitchDirective()
    {
        string normalDirective = "Directive: Return back t";
        yield return StartCoroutine(TypeText(normalDirective));
        
        yield return new WaitForSeconds(1.5f);
        if (glitchSound) glitchSound.Play();
        

        directiveText.text = "Directive: R̸̨̝͎̹̆͂̎̕e̶̦͍͖̅̐t̷̡̹͖̀̿̏̕͠u̴̠̬͉̥̿̈́̄r̵̲̪̗̎n̶̡͈̝̹̎̍̚ ̵̩̥̩̤͋b̵̬̠̲̙̊̋ä̵̙̒c̶̥̐̾͠k̷͙̼̪̼̆̾̈́ ";
        yield return new WaitForSeconds(0.8f);

        directiveText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(glitchColor)}>{newDirective}</color>";
        yield return new WaitForSeconds(displayTime);
        directiveText.text = "";
    }


    IEnumerator TypeText(string textToType)
    {
        directiveText.text = "";
        foreach (char letter in textToType)
        {
            directiveText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
