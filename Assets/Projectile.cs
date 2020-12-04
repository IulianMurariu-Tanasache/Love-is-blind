using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        transform.position = transform.position + transform.forward * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.tag == "perete")
        {
            Destroy(gameObject);
        }
    }




}
