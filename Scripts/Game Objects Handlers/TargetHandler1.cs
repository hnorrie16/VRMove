using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

using static StaticVar;

public class TargetHandler1 : MonoBehaviour
{
    GameObject[] targets;

    GameObject player;

    public GameObject scoreText;

    public Collider[] colliders;

    public bool hasBeenHit = false;

    private int currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        currentTime += 1;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        scoreText = GameObject.FindWithTag("score");
        targets = GameObject.FindGameObjectsWithTag("target");

    }

    /*
    ** Function that finds all targets within a certain distance and adds them to a list of colliders.
    ** Returns list of colliders (List<Colliders)
    */

    // public List<Collider> target_cols = new List<Collider>();
    // public int globalRad = 0;
    
    public List<Collider> FindTargetsInDistance(int radius)
    {
        Debug.Log("RADIUS: " +  radius);
        List<Collider> target_cols = new List<Collider>();
Debug.Log("Player: " + player.transform.position);
        // globalRad = radius;
        if(target_cols.Count == 0){
  colliders = Physics.OverlapSphere(player.transform.position, radius);
                    Debug.Log("COLLIDERS FOUND: " + colliders.Length);
                    foreach (Collider c in colliders) {
                        float dist = Vector3.Distance(player.transform.position, c.transform.position);
                        Debug.Log("DIST: " + dist + "\n" + "TAG: " + c.gameObject.tag);
                        
                        if (c.gameObject.tag == "target" && ( 40 < dist) && ( dist < 51 )) {
                            Debug.Log ("target " + c + " in range " + dist);
                            target_cols.Add (c);
            }
        }
        }

               if(target_cols.Count == 0){
  colliders = Physics.OverlapSphere(player.transform.position, radius);
                    Debug.Log("COLLIDERS FOUND: " + colliders.Length);
                    foreach (Collider c in colliders) {
                        float dist = Vector3.Distance(player.transform.position, c.transform.position);
                        if (c.gameObject.tag == "target" && ( 32 < dist) && ( dist < 58 )) {
                            Debug.Log ("target " + c + " in range " + dist);
                            target_cols.Add (c);
            }
        }
        }




                  



        // globalRad += 10;

        return target_cols;
            
    
        
        
    }

    // public bool FoundSomethingInRadius(int radius) {
       
    //     if(target_cols.Count > 0) {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    /*
    ** Function that selects a random target from a list of colliders.
    */
    public void PickTargetFromArray(List<Collider> collidersArg)
    {
        // Random random = new Random();
        // int index = random.Next(0, collidersArg.Count);
        int index = Random.Range(0, collidersArg.Count);
        // Debug.Log("Index is: " + index);
        // Debug.Log("Length of arr: " + collidersArg.Count);
        // if (collidersArg[index])
        // {
        //     Debug.Log("Something there is: " + collidersArg[index]);
        // }
        // else
        // {
        //     Debug.Log("Nothing there");
        // }
        Collider col = collidersArg[index];
        // Debug.Log("Collider: " + col);
        static_col = col;
        // Debug.Log("Static: " + static_col);
        static_col.GetComponent<Renderer>().enabled = true;
        targetTrajectory
            .Add(new PlayerCoordinate(currentTime,
                static_col.gameObject.transform.position.x,
                player.transform.position.y,
                player.transform.position.z));
    }

    /*
    ** Function that selects a random target from a list of colliders.
    */
    private void OnCollisionEnter(Collision other)
    {
        if (!hasBeenHit)
        {
            hasBeenHit = true;

            if (other.gameObject.tag != "terrain" && gameObject.GetComponent<Renderer>().enabled == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                System.Random r = new System.Random();
                int randomRadius = r.Next(40, 50);

                List<Collider> targetCollidersInRange = FindTargetsInDistance(randomRadius);
        
                // List<Collider> targetCollidersInRange = target_cols;
                
                Debug.Log("There are " + targetCollidersInRange.Count + " targets in the radius " + randomRadius);

                // if(col.Count == 0) {
                //     List<Collider> col = FindTargetsInDistance(randomRadius+10);
                //     Debug.Log(randomRadius);
                // }
                // if(col.Count != 0) {
                //     PickTargetFromArray (col);
                // } else {
                //     List<Collider> col = FindTargetsInDistance(randomRadius);
                // }

                PickTargetFromArray (targetCollidersInRange);
                StaticVar.score += 1;
                scoreText.GetComponent<UnityEngine.UI.Text>().text =
                    "Score: " + StaticVar.score;
                StartCoroutine(waitTillHitAgain());
            }
        }
    }

    public IEnumerator waitTillHitAgain()
    {
        yield return new WaitForSeconds(1);
        hasBeenHit = false;
    }
}
