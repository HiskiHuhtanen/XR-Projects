using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationController : MonoBehaviour
{
    public Animator handAnimator;
    
    [Header("Input Actions")]
    public InputActionReference gripAction;
    public InputActionReference triggerAction;

    void Update()
    {
        if (handAnimator != null)
        {
            float gripValue = gripAction.action.ReadValue<float>();
            float triggerValue = triggerAction.action.ReadValue<float>();

            handAnimator.SetFloat("Grip", gripValue);
            handAnimator.SetFloat("Trigger", triggerValue);
        }
    }
}
