using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class SwingingArmMotion : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject CenterEyeCamera;
    public GameObject ForwardDirection;
    public GameObject player;

    

    public SteamVR_Action_Boolean disk;

    private Vector3 PositionPreviousFrameLeftHand;
    private Vector3 PositionPreviousFrameRightHand;
    private Vector3 PlayerPosPrevFrame;
    private Vector3 PlayerPosThisFrame;
    private Vector3 PositionThisFrameLeftHand;
    private Vector3 PositionThisFrameRightHand;
    private Vector3 tempPos;

    public float Speed;
    private float HandSpeed;

    public bool justClicked = true;

    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        PlayerPosPrevFrame = transform.position;
        PositionPreviousFrameLeftHand = LeftHand.transform.position;
        PositionPreviousFrameRightHand = RightHand.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (disk.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            justClicked = true;
        }

        //SteamVR_Input_Sources.RightHand only gets right handed
        if (disk.GetState(SteamVR_Input_Sources.RightHand) && disk.GetState(SteamVR_Input_Sources.LeftHand))
        {

            if(justClicked){
                PlayerPosPrevFrame = transform.position;
                PositionPreviousFrameLeftHand = LeftHand.transform.position;
                PositionPreviousFrameRightHand = RightHand.transform.position;
                justClicked = false;
            }

        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        PositionThisFrameRightHand = RightHand.transform.position;
        PositionThisFrameLeftHand = LeftHand.transform.position;
        PlayerPosThisFrame = transform.position;

        var playerDistanceMoved = Vector3.Distance(PlayerPosThisFrame, PlayerPosPrevFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositionThisFrameLeftHand, PositionPreviousFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositionThisFrameRightHand, PositionPreviousFrameRightHand);
   
        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        if(Time.timeSinceLevelLoad > 1f)
        {
        
            transform.position += ForwardDirection.transform.forward * HandSpeed * Speed * Time.deltaTime;
            // RaycastHit hit;

            // Ray ray = new Ray(player.transform.position, -Vector3.up);

            // if (Physics.Raycast(ray, out hit))
            // {
            //     Debug.Log(hit.point.y);
            //     transform.position = new Vector3(transform.position.x, hit.point.y + 1f, transform.position.z);
            // }

                    
        }

        PositionPreviousFrameLeftHand = PositionThisFrameLeftHand;
        PositionPreviousFrameRightHand = PositionThisFrameRightHand;
        PlayerPosPrevFrame = PlayerPosThisFrame;
        }


        //Set current player position to the previous position

    }

    IEnumerator waitforawhile(){

      yield return new WaitForSeconds(2);
    
    }
 
}
