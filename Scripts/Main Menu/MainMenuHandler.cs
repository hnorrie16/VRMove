/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        //Saving controls in STATIC VAR class so when we load a scene we know 
        //which control scheme to use

        if (e.target.name == "btn_teleport"){
            Debug.Log("TELE");

        } else if (e.target.name == "btn_arm_swinging") {
            SceneManager.LoadScene("ArmSwingingTraining");

        } else if (e.target.name == "btn_cradle") {
            Debug.Log("CRAD");
        } 
 


    }

    public void PointerInside(object sender, PointerEventArgs e)
    {

    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {

    }
}
