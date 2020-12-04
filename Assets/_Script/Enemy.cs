using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public Rigidbody rb;
    public float moveSpeed;
    public int hp = 1;
    public Player pulic;
    public int type;
    public GameObject projectile;
    public int fireRate;

    private void Start()
    {
        player = GameObject.FindWithTag("player");
        rb = GetComponent<Rigidbody>();
        pulic = player.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        transform.LookAt(player.transform);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            pulic.nrEnemies--;
            //StartCoroutine(GoLat());
        }
        switch(type)
        {
            case 0:
            default:
                break;
            case 1:
                Fire();
                break;
                            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bata" && pulic.atack == true)
            hp--;
        if (collision.collider.tag == "player")
            pulic.hp--;
    }

    IEnumerator Fire()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
    }

    /*IEnumerator GoLat()
    {
        
    }*/

}
