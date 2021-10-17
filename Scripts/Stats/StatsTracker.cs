using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticVar;
using System.IO;
using Valve.VR;

public class StatsTracker : MonoBehaviour
{
    GameObject player;
    public SteamVR_Action_Boolean disk;
    private float time = 2;
    private float timeRemaining = 2;
    bool writtenToFile = false;
    private int currentTime = 0;




    List<StaticVar.PlayerCoordinate> playerTrajectory = new List<StaticVar.PlayerCoordinate>();
    List<StaticVar.PlayerCoordinate> targetTrajectory = new List<StaticVar.PlayerCoordinate>();


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        timeRemaining = time;
    }

    // Update is called once per frame
    void Update()
    {

            currentTime += 1;
          

        if(gameFinished){
            // Write list to a CSV file.

            //Writing position log
            if(!writtenToFile){
                using (StreamWriter w = File.AppendText("positionLog.csv")){
                   
            w.WriteLine("time,x,y,z");
            foreach(PlayerCoordinate pc in playerTrajectory){
                w.WriteLine(pc.time + "," + string.Format("{0:N2}", pc.x).Replace(",",".") + "," + string.Format("{0:N2}", pc.y).Replace(",",".") + "," + string.Format("{0:N2}", pc.z).Replace(",","."));
            }
                }
            //Writing shots taken and score
            using (StreamWriter ws = File.AppendText("shotsData.csv")){
                   
            ws.WriteLine("Total Shots," + StaticVar.shotsTaken.ToString());
            ws.WriteLine("Score," + StaticVar.score.ToString());

         
            }


    using (StreamWriter w = File.AppendText("targetPositionositionLog.csv")){
                   
            w.WriteLine("time,x,y,z");
            foreach(PlayerCoordinate pc in StaticVar.targetTrajectory){
                w.WriteLine(pc.time + "," + string.Format("{0:N2}", pc.x).Replace(",",".") + "," + string.Format("{0:N2}", pc.y).Replace(",",".") + "," + string.Format("{0:N2}", pc.z).Replace(",","."));
            }
                }

                    writtenToFile = true;
            }
       
              
            
            }
    
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

           

        } else {
            timeRemaining = time;

            //Log a position from the map
          

            playerTrajectory.Add(new PlayerCoordinate(currentTime, player.transform.position.x,player.transform.position.y,player.transform.position.z));

        }



        //Checking time between aim and shoot
        //Get hand thats holding bow
        //CHeck when that trigger is pressed (And other NOT being pressed)
        //Start a timer
        //Check when arrow shot (Right trigger released) - Although sometimes they won't sshoot - Check for arrow shot method

    }
}
