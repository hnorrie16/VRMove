using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticVar;

public class SceneTargetHandler : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject [] targets;
    GameObject player;
    public TargetHandler tg;

            
    void Start()
    {

        //Finding Initial Targets within Radius
        player = GameObject.FindWithTag("Player");
        targets = GameObject.FindGameObjectsWithTag("target");

        foreach (GameObject item in targets)
        {
           item.GetComponent<Renderer>().enabled = false;
        }
        
        Collider [] colliders;
        List<Collider> target_cols = new List<Collider>();
         colliders = Physics.OverlapSphere(player.transform.position, 20f);
         
         foreach (Collider c in colliders)
         {
             if(c.gameObject.tag == "target"){
                 target_cols.Add(c);
             }
         }

        // Selecting Initital Target
            System.Random random = new System.Random();
            int index = random.Next(target_cols.Count);
            Collider col = target_cols[index];
            static_col = col;
            col.GetComponent<Renderer>().enabled = true;

  

        // =============================================================================


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
