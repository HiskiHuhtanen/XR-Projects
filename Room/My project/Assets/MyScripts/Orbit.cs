using UnityEngine;

public class OrbitScript : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10f * Time.deltaTime, 0);
    }
}
