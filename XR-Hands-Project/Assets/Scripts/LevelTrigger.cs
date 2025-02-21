using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public ParticleSystem smokeParticles;
    public GameObject blockingCollider; 
    public string hiddenLayer = "Hidden";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lever"))
        {
            HideSmoke();
            RemoveBlock();
        }
    }

    private void HideSmoke()
    {
        if (smokeParticles != null)
        {
            // Change the rendering layer of all particle system renderers to Hidden
            var renderers = smokeParticles.GetComponentsInChildren<ParticleSystemRenderer>();
            foreach (var renderer in renderers)
            {
                renderer.gameObject.layer = LayerMask.NameToLayer(hiddenLayer);
            }
        }
    }

    private void RemoveBlock()
    {
        if (blockingCollider != null)
        {
            blockingCollider.SetActive(false);
        }
    }
}
