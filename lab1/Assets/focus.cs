using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focus : MonoBehaviour
{
    public Transform target;  // The target that the camera will focus on

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

    }
}
