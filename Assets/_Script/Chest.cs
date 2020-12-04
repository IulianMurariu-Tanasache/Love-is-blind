using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    public TextMeshPro costText;
    public int cost;
    public GameObject player;
    public Player playerScript;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
        playerScript = player.GetComponent<Player>();
        cost = playerScript.itemCost[playerScript.itemSpawed];
    }

    private void Update()
    {
        costText.text = "$ " + cost.ToString();
    }
}
