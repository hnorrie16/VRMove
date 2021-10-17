using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

using static Valve.VR.SteamVR_TrackedObject;

public class CradleMotion : MonoBehaviour
{
    public GameObject CenterEyeCamera;

    public GameObject ForwardDirection;

    public GameObject player;

    private Vector3 origin;

    private Vector3 currentPosRelativeToOrigin;

    public float Speed;

    private float HandSpeed;

    public bool isOriginSet = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentPosRelativeToOrigin = origin;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOriginSet)
        {
            origin = new Vector3(pose.pos.x, pose.pos.y, pose.pos.z);
            isOriginSet = true;
        }

        float yRotation = CenterEyeCamera.transform.eulerAngles.y;

        Vector3 disp = calcDisplacement(currentPosRelativeToOrigin, origin);
        Debug.Log(disp);

        currentPosRelativeToOrigin =
            new Vector3(pose.pos.x, pose.pos.y, pose.pos.z);
        float dist = 10 * Vector3.Distance(currentPosRelativeToOrigin, origin);
        if (dist > 0.1f)
        {
            player.transform.position += new Vector3(disp.x,0,(disp.z*2f)) * Speed * dist * Time.deltaTime;
                // ForwardDirection.transform.position *
                // Speed *
                // dist *
                // Time.deltaTime;
        }
    }

    Vector3 calcDisplacement(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }
}
