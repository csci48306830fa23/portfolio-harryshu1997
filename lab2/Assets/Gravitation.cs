using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Gravitation : MonoBehaviour
{
    public Rigidbody rb;
    public static List<Gravitation> Bodies;
    public float gravitationalConstant = 1.0f;

    private void OnEnable()
    {
        if (Bodies == null)
            Bodies = new List<Gravitation>();

        Bodies.Add(this);
        rb = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        Bodies.Remove(this);
    }

    void FixedUpdate()
    {
        foreach (Gravitation body in Bodies)
        {
            if (body != this)
                Attract(body);
        }
    }

    void Attract(Gravitation objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = gravitationalConstant * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
