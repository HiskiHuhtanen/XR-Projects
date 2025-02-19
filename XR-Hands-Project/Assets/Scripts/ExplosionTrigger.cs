using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionTrigger : MonoBehaviour
{
    public AudioClip explosionSound;  // Assign in Inspector
    public GameObject explosionEffect; // Assign a VFX or Particle System
    public float explosionDelay = 2f; // Time before scene change

    private bool hasExploded = false; // Prevent multiple triggers

    public void TriggerExplosion()
    {
        if (!hasExploded)
        {
            hasExploded = true;
            StartCoroutine(ExplosionSequence());
        }
    }

    private IEnumerator ExplosionSequence()
    {
        // Play explosion sound
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // Spawn explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Wait before changing scenes
        yield return new WaitForSeconds(explosionDelay);

        // Load the next scene (make sure scenes are in Build Settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
