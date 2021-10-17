using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticVar;

public class ArrowShotTracker : MonoBehaviour
{

    public bool hasBeenHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {

      
        Debug.Log(other.gameObject.tag);

        if (!hasBeenHit)
        {
            hasBeenHit = true;

                StaticVar.shotsTaken += 1;
                StartCoroutine(waitTillHitAgain());

        }

    }


        public IEnumerator waitTillHitAgain()
    {
        yield return new WaitForSeconds(1);
        hasBeenHit = false;
    }
}
