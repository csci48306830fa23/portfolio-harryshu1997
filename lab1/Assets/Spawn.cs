using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform respawnPoint; // Drag and drop your respawn point in the inspector
    private Rigidbody rb;
    public float minVelocity = 0; // Minimum random velocity
    public float maxVelocity = 1f;  // Maximum random velocity
    private void OnCollisionEnter(Collision collision)  
    {
        if(collision.gameObject.tag == "Floor") // Ensure your floor object has the tag "Floor"
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        if (rb != null)
        {
            Vector3 randomVelocity = new Vector3(
            Random.Range(minVelocity, maxVelocity),
            Random.Range(minVelocity, maxVelocity),
            Random.Range(minVelocity, maxVelocity)
            );

            rb.velocity = randomVelocity; // Set random linear velocity
            rb.angularVelocity = Vector3.zero; // Reset angular velocity
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
