using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SphereController : MonoBehaviour
{
    
    public SteamVR_Action_Boolean disk;
    public GameObject teleportSphere;
    // Start is called before the first frame update
    private void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if (disk.GetState(SteamVR_Input_Sources.RightHand))
        {
      
            teleportSphere.SetActive(false);
           // teleportSphere.GetComponent<Renderer>().enabled = false;

        }
        else if (disk.GetStateUp(SteamVR_Input_Sources.RightHand))
        {

            //teleportSphere.SetActive(true);
        }

    }
}
