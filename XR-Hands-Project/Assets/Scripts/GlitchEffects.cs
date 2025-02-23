using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlitchEffect : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private ChromaticAberration chromaticAberration;
    private Vignette vignette;
    private Grain grain;
    public AudioSource glitchSound;  // Add your glitch sound here
    private float glitchIntensity = 0f;  // Initial glitch intensity

    // A list of the trigger zones (boxes or other colliders) in the scene
    public Collider[] glitchTriggers;

    void Start()
    {
        // Get PostProcessProfile settings
        if (postProcessVolume.profile.TryGetSettings(out chromaticAberration))
        {
            chromaticAberration.intensity.value = 0f; // Start with no effect
        }

        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = 0f; // Start with no effect
        }

        if (postProcessVolume.profile.TryGetSettings(out grain))
        {
            grain.intensity.value = 0f; // Start with no effect
        }
    }

    void Update()
    {
        // We check if the player is inside any of the glitch triggers
        foreach (var trigger in glitchTriggers)
        {
            if (trigger.bounds.Contains(transform.position))
            {
                // Apply the glitch effect progressively as the player enters more triggers
                ApplyGlitchEffect(0.3f);  // Adjust this value based on the trigger's intensity
                return;  // Exit as soon as the player is in any trigger
            }
        }
        
        // If the player is not in any glitch trigger, reset the effect
        ResetGlitchEffect();
    }

    private void ApplyGlitchEffect(float intensity)
    {
        // Increase the glitch intensity gradually
        glitchIntensity = Mathf.Lerp(glitchIntensity, intensity, Time.deltaTime * 2f);  // Adjust speed as needed
        
        // Apply the glitch effect
        chromaticAberration.intensity.value = glitchIntensity;
        vignette.intensity.value = glitchIntensity;
        grain.intensity.value = glitchIntensity * 1.5f;  // Slightly stronger grain effect

        // Play glitch sound if it's not already playing
        if (glitchSound && !glitchSound.isPlaying)
        {
            glitchSound.Play();
        }
    }

    private void ResetGlitchEffect()
    {
        // Reset the glitch intensity if the player is not in any glitch triggers
        glitchIntensity = 0f;

        // Stop the glitch sound if playing
        if (glitchSound && glitchSound.isPlaying)
        {
            glitchSound.Stop();
        }

        // Reset the effect values
        chromaticAberration.intensity.value = 0f;
        vignette.intensity.value = 0f;
        grain.intensity.value = 0f;
    }
}
