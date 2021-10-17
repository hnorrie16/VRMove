using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;
using static StaticVar;

public class Arrow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(static_col.gameObject.transform.position);

        //transform.LookAt(1.982f * gameObject.transform.position - static_col.gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "projectile" && gameObject.name == "target_1"){
            target_1 = true; 
        } 
            else if(other.gameObject.tag == "projectile" && gameObject.name == "target_2"){
            target_2 = true;
        }
            else if(other.gameObject.tag == "projectile" && gameObject.name == "target_3"){
            target_3 = true;
        }
            else if(other.gameObject.tag == "projectile" && gameObject.name == "target_4"){
            // SceneManager.LoadSceneAsync(toNextEnvironemnt);
        }
    }


    
}
