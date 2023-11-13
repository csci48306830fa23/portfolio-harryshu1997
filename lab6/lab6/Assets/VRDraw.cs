using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDraw : MonoBehaviour
{
    public GameObject spherePrefab;
    public float sphereSize = 0.01f;
    public float minDistance = 0f; // Minimum distance between consecutive spheres
    public Transform ControllerRight;
    public float deletionDistance = 0.02f; // Distance threshold for deletion

    private Vector3 lastSpherePosition;
    private bool hasLastSphere = false;
    private List<GameObject> createdSpheres = new List<GameObject>(); // Store all created spheres



    void Update()
    {
        // Check for input
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0)
        {
            Debug.Log("Drawing Sphere"); // Debug line
            if (!hasLastSphere || Vector3.Distance(ControllerRight.position, lastSpherePosition) >= minDistance)
            {
                GameObject newSphere = DrawSphere();
                createdSpheres.Add(newSphere); // Add the new sphere to the list
                lastSpherePosition = ControllerRight.position;
                hasLastSphere = true;
            }
        }
        // Sphere deletion
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            DeleteNearbySphere();
        }
    }

    GameObject DrawSphere()
    {
        GameObject sphere = Instantiate(spherePrefab, ControllerRight.position, Quaternion.identity);
        sphere.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
        return sphere;
    }

    void DeleteNearbySphere()
    {
        if (createdSpheres.Count > 0)
        {
            GameObject lastSphere = createdSpheres[createdSpheres.Count - 1];
            createdSpheres.RemoveAt(createdSpheres.Count - 1);
            Destroy(lastSphere);
        }
    }


}
