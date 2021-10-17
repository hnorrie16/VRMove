using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class StaticVar : MonoBehaviour
{
   
    public static int trainingScore = 0;
    public static bool target_1 = false;
    public static bool target_2 = false;
    public static bool target_3 = false;
    public static Collider static_col;
    public static int score = 0;
    public static int shotsTaken = 0;
    public static string toNextEnvironemnt;
    public static bool gameFinished = false;
    

    public struct PlayerCoordinate
    {
        public float x;
        public float z;
        public float y;
        public int time;

        public PlayerCoordinate( int time,float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.time = time;
        }
    }

    public static List<PlayerCoordinate> targetTrajectory = new List<PlayerCoordinate>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {



    }

}
