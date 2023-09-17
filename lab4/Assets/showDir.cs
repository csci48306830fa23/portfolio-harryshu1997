using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class showDir : MonoBehaviour
{
    public Transform target;  // The Transform you want to point to
    public Image arrowImage;  // Drag the arrow UI Image here
    public Camera mainCamera; // Drag your main camera here
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   

    private void Update()
    {
        Vector3 direction = target.position - mainCamera.transform.position;
        Vector3 cameraRelativeDirection = mainCamera.transform.InverseTransformDirection(direction);

        // Calculate angle to rotate
        float angle = Mathf.Atan2(cameraRelativeDirection.x, cameraRelativeDirection.y) * Mathf.Rad2Deg;

        // Apply rotation
        arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
