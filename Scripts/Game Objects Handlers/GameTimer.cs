using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static StaticVar;

public class GameTimer : MonoBehaviour
{
    private float timeRemaining = 600;
    private GameObject UI;
    GameObject longbow;
    Transform final_words;

    private void Start() {
        UI = GameObject.FindWithTag("UI");
        longbow = GameObject.Find("Longbow");
        final_words = UI.transform.Find("FinishedText");
        final_words.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Time remaining: " + timeRemaining);
            UI.transform.Find("Timer").GetComponent<UnityEngine.UI.Text>().text = "Time remaining: " + (Convert.ToInt32(timeRemaining)/60) + "." + (Convert.ToInt32(timeRemaining)%60);

        } else {
            //Debug.Log("Finished!");
            StaticVar.gameFinished = true;
            final_words.gameObject.SetActive(true);            
            //Debug.Log(longbow.GetComponent<Valve.VR.InteractionSystem.Longbow>());
            StartCoroutine(Wait());
            
            //Add in stats screen if there is time

        }
    }

    IEnumerator Wait()
{
	//To wait, type this:
  
  	//Stuff before waiting
	yield return new WaitForSeconds(5);
    Application.Quit();
 
}

}