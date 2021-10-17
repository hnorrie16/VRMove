using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{       

    public float height;
    public Transform objectToPlace;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        
        if (Physics.Raycast(ray, out hit)){
            if(hit.collider.tag == "trainingPad"){
               objectToPlace.position = hit.point;
               objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
        }

    }
}
