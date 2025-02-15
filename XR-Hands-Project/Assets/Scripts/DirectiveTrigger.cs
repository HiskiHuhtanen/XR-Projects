using UnityEngine;
using TMPro;
using System.Collections;

public class DirectiveTrigger : MonoBehaviour
{
    public TextMeshProUGUI directiveText;
    public string newDirective = "Directive: Delve Deeper"; // Custom message per trigger
    public float displayTime = 5f; // Total time before disappearing
    public Color glitchColor = new Color(1f, 0f, 1f); // Pink color for glitch
    public AudioSource glitchSound; // Assign a glitch SFX in Inspector

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
        // Show normal directive first
        directiveText.text = "Directive: Return to Charging Station";

        yield return new WaitForSeconds(1.5f); // Show for 1.5 sec before glitch

        // Play glitch sound
        if (glitchSound) glitchSound.Play();

        // Apply corrupted text effect (glitching)
        directiveText.text = "Directive: R̸̨̝͎̹̆͂̎̕e̶̦͍͖̅̐t̷̡̹͖̀̿̏̕͠u̴̠̬͉̥̿̈́̄r̵̲̪̗̎n̶̡͈̝̹̎̍̚ ̵̩̥̩̤͋b̵̬̠̲̙̊̋ä̵̙̒c̶̥̐̾͠k̷͙̼̪̼̆̾̈́ ̶̳̾t̵̹̘͚̊͐̕o̷͖̬͎̾̄͌ ̵̢̞̘͆̋̂c̵̟̤̩͋̽̾̈́ḧ̷̯̖̦́͌͠ą̴̦̙̉̋r̷̙̳͆̓͂͠g̶̛̪̰̾̆ì̵̛̘͕̯n̵̲̞̠̑̈́̿̏g̴̲͆͊̿͠ ̴̜̔̚s̴̳̬̏̐ẗ̴̺̜́̄͑a̷̝̥̕t̶̝̾i̶̹̤̿̓o̵̹̼̍͌̓n̵̠̄";

        yield return new WaitForSeconds(0.8f); // Hold the glitch effect

        // Change to the new directive (in pink)
        directiveText.text = $"<color=#{ColorUtility.ToHtmlStringRGB(glitchColor)}>{newDirective}</color>";

        yield return new WaitForSeconds(displayTime); // Keep new directive on screen

        // Hide the text
        directiveText.text = "";
    }
}
