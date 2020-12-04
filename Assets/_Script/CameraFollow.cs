using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 target;
    public float cameraSpeed,y,z;
    public bool cameraEnter;
    public Vector3 pos;

    private void LateUpdate()
    {
        if (cameraEnter == false)
        {
            target = player.transform.position + player.transform.up * y + player.transform.forward * z; ;
            transform.position = Vector3.Lerp(transform.position, target, cameraSpeed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
    }

    private void Update()
    {
        if(cameraEnter == true)
        {
            transform.position = pos;
            //transform.LookAt(player.transform);
        }
    }
}
