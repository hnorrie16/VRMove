using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGroundCubeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject [] targets;
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("target");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        // Check if player is holding bow then make the targets appear
        foreach (GameObject item in targets)
        {
            item.SetActive(true);
        }
    }
}
