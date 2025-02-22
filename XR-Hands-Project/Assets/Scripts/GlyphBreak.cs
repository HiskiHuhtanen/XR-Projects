using UnityEngine;

public class GlyphDestruction : MonoBehaviour
{
    public GameObject door;
    public AudioSource hitSound;
    public GameObject[] glyphParts;

    private int hitCount = 0;
    private const int maxHits = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FUSE"))
        {
            hitCount++;
            if (hitSound != null)
                hitSound.Play();
            if (hitCount <= glyphParts.Length)
            {
                Destroy(glyphParts[hitCount - 1]); 
            }
            if (hitCount >= maxHits && door != null)
            {
                Destroy(gameObject);
                Destroy(door.GetComponent<Collider>());
                door.layer = LayerMask.NameToLayer("Hidden");
            }
        }
    }
}
