using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAboveGround : MonoBehaviour
{
    public float floatValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
         RaycastHit hit;
         if (Physics.Raycast (new Vector3(gameObject.transform.position.x,gameObject.transform.position.y + 0.08f,gameObject.transform.position.z), Vector3.down, out hit)) {
             gameObject.transform.Translate (0, (floatValue - hit.distance), 0);
         }
    }
}
