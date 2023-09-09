using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your Bullet prefab in the Inspector
    public Transform gunTip;        // Assign the gun tip/muzzle in the Inspector
    public float bulletSpeed = 20f;

    private float lifeTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Instantiate bullet at the gun tip's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        
        // Destroy the bullet after 5 seconds
        Destroy(bullet, lifeTime);
        
        // Assuming your bullet has a Rigidbody component
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = gunTip.forward * bulletSpeed; // gunTip.forward gives the forward direction of the gun tip
        }
    }
}
