using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] invetoryAdd = new Image[10];
    public Sprite[] items = new Sprite[5];
    public int i = 0;


    public void InvetoryAdd(int index)
    {
        foreach (Image i in invetoryAdd)
        {
            if (i.enabled == false)
            {
                i.enabled = true;
                i.sprite = items[index];
                break;
            }
        }

    }

    public void InvetoryRemove(int index)
    {
        invetoryAdd[index].enabled = false;
    }

}
