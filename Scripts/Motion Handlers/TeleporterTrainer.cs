using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR;

public class TeleporterTrainer : MonoBehaviour
{
    GameObject player;
    public GameObject m_Pointer;
    public GameObject m_Ground;
    public SteamVR_Action_Boolean disk;
    public SteamVR_Action_Boolean m_TeleportationAction;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;
    private bool m_IsTeleporting = false;
    private float m_FadeTime = 0.4f;
    public float maxDis;


    private void Awake() {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (disk.GetState(SteamVR_Input_Sources.RightHand) || disk.GetState(SteamVR_Input_Sources.LeftHand))
        {
            
            m_Pointer.GetComponent<Renderer>().enabled = false;

        }
        else{
            //Pointer
            StartCoroutine(showPointerAfterWait());
            m_HasPosition = UpdatePointer();
            m_Pointer.SetActive(m_HasPosition);

            //Teleport
            if (m_TeleportationAction.GetStateUp(m_Pose.inputSource)){
            
            
  
    
                    TryTeleport();

  


         }



            
        }




    }

     private IEnumerator showPointerAfterWait(){

        yield return new WaitForSeconds(1f);
        m_Pointer.GetComponent<Renderer>().enabled = true;
    }

    private void TryTeleport(){

        //Check for valid pos or already teleporting
        if(!m_HasPosition || m_IsTeleporting){
            return;
        }

        Transform cameraRig = SteamVR_Render.Top().origin;
        Vector3 hadPosition = SteamVR_Render.Top().head.position;
        Vector3 groundPos = new Vector3(hadPosition.x, cameraRig.position.y, hadPosition.z);
        Vector3 trans = m_Pointer.transform.position - groundPos;
        


        StartCoroutine(MoveRig(cameraRig, trans));



    }

    private IEnumerator MoveRig(Transform camRig, Vector3 translation){

        
        m_IsTeleporting = true;
        SteamVR_Fade.Start(Color.black, m_FadeTime, true);
        yield return new WaitForSeconds(m_FadeTime);
        camRig.position += translation;
        SteamVR_Fade.Start(Color.clear, m_FadeTime, true);
        m_IsTeleporting = false;
    }

    private bool UpdatePointer(){
        //Ray from controller
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
                m_Pointer.transform.position = hit.point;
                
                
                float dist = Vector3.Distance(player.transform.position, m_Pointer.transform.position);


                 var rend = m_Pointer.GetComponent<Renderer>();
                if(dist > maxDis){
                    rend.material.SetColor("_Color", Color.red);
                } else {
                    rend.material.SetColor("_Color", Color.yellow);
                }
            return true;
        }
        return false;
    }


}
