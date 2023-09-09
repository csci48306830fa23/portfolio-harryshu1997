using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public Camera mainCamera; 

    // Screen boundaries in world coordinates
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Convert screen dimensions in pixels to world coordinates
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
        // Get the size of the gun (or any attached Collider2D)
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x; // Extents is half the size
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = mainCamera.transform.position.z + 5f; // adjust the z value accordingly

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
    
    }
}
