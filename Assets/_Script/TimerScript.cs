using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float time;
    public Animator animator;

    private void Update()
    {
        time = time - 1.0f;
        animator.SetFloat("timer", time);
        if(time<=0)
        {
            Debug.Log("gata coe");
            time = 900f;
        }
    }
}
