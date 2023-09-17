using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{
    public float attractionForce = 10f;       // The maximum attraction force
    public float attractionRadius = 5f;       // The maximum distance at which the player gets attracted

    private Rigidbody playerRb;                // Rigidbody of the player

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            playerRb = player.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb)
        {
            Vector3 directionToPlayer = playerRb.transform.position - transform.position;
            float distance = directionToPlayer.magnitude;

            if (distance < attractionRadius)
            {
                float forceMagnitude = (1 - (distance / attractionRadius)) * attractionForce;
                Vector3 force = directionToPlayer.normalized * forceMagnitude;

                playerRb.AddForce(force);
            }
        }
    }
}
