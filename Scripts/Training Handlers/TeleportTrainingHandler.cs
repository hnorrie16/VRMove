using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static StaticVar;

public class TeleportTrainingHandler : MonoBehaviour
{
 public Text instruction;

    GameObject player;

    GameObject longbow;

    GameObject[] targets;

    GameObject final_target;

    public bool pickedUp = false;

    public bool training2 = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        longbow = GameObject.FindWithTag("bow");
        targets = GameObject.FindGameObjectsWithTag("target");
        final_target = GameObject.FindWithTag("final_target");
        final_target.SetActive(false);
        foreach (GameObject item in targets)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -Vector3.up);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "trainingPad")
            {

                GameObject floorPad = GameObject.FindWithTag("trainingPad");
                var rend = floorPad.GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.red);
                foreach (GameObject item in targets)
                {
                    item.SetActive(true);
                }
            }
        }

        if (target_1 && target_2 && target_3)
        {
            toNextEnvironemnt = "Teleport";
            final_target.SetActive(true);
        }
    }
}

