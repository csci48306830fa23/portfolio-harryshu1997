using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float turnSpeed = 60f;          // Speed of yaw rotation in degrees per second
    public float pitchSpeed = 30f;         // Speed of pitch rotation
    public float rollSpeed = 45f;          // Speed of roll rotation
    public float acceleration = 10f;       // Speed added per second on forward arrow press
    public float deceleration = 5f;        // Speed subtracted per second on backward arrow press
    public float maxSpeed = 150f;          // Maximum forward speed
    public float minSpeed = 10f;           // Minimum forward speed

    private float currentSpeed = 0f;       // Current speed of the plane

    void Update()
    {
        // Yaw rotation using left and right arrows
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        // Roll (banking) when turning
        float roll = -Input.GetAxis("Horizontal") * rollSpeed * Time.deltaTime;
        transform.Rotate(0, 0, roll);

        // Accelerate or decelerate using up and down arrows
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
            
            // Pitch the nose down slightly during acceleration
            transform.Rotate(-pitchSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
            
            // Pitch the nose up slightly during deceleration
            transform.Rotate(pitchSpeed * Time.deltaTime, 0, 0);
        }

        // Move the plane forward based on current speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
