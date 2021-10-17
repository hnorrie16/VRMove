using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static StaticVar;

public class ArrowFollowHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        // Debug.Log(static_col.name);
        transform.LookAt(static_col.gameObject.transform.position);
        gameObject.transform.Rotate(0, 180, 0);

        Vector3 spawnPos =
            player.transform.position + player.transform.forward * 2f;
        transform.position = spawnPos + offset;
    }
}
