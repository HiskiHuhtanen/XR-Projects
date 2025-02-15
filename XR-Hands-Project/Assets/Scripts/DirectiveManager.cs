using UnityEngine;
using TMPro;
using System.Collections;

public class DirectiveManager : MonoBehaviour
{
    public TextMeshProUGUI directiveText;

    void Start()
    {
        StartCoroutine(ShowFirstDirective());
    }

    IEnumerator ShowFirstDirective()
    {
        yield return new WaitForSeconds(2);
        directiveText.text = "Directive: Return to Charging Station";
        yield return new WaitForSeconds(5); 
        directiveText.text = "";
    }
}
