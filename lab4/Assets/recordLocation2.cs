using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordLocation2 : MonoBehaviour
{
     private Vector3 recordedPosition;
     public Transform player;
    public TMPro.TextMeshProUGUI textObject;
    // Start is called before the first frame update
    void Start()
    {
         
    }
    void RecordPosition()
    {
        recordedPosition = player.position;
        //Debug.Log("Player's recorded position: " + recordedPosition);
        textObject.text = "Scene 2 Player's recorded position: " + recordedPosition;

    }
    // Update is called once per frame
    void Update()
    {
        
        RecordPosition();
        
    }
}
