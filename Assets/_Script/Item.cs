using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemIndex;
    public float y;
    public Vector3 target;
    public float speed;
    public int cost;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);  
    }
}
