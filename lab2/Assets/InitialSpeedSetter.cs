using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpeedSetter : MonoBehaviour
{
    public Vector3 initialVelocity = new Vector3(1f, 0f, 0f);  // Default is along the x-axis

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = initialVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
