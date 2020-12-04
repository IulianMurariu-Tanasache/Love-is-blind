using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float movementSpeed ,rotSpeed;
    public Rigidbody rb;
    public float hp = 3;
    public Image[] inimi = new Image[3];
    public Sprite[] inimiSprite = new Sprite[2];
    public bool diff = false;
    public GameObject inventory,inventoryAdaos;
    public Inventory invent;
    public int invetSelect;
    public RaycastHit hit;
    public float maxDistance;
    public int money;
    public TextMeshProUGUI textMoney;
    public int[] itemCost = new int[1];
    public int itemSpawed;
    public Animator animator;
    public bool atack;
    public int nrEnemies;

    private void Start()
    {
        foreach (Image i in inimi)
        {
            i.sprite = inimiSprite[0];
            
        }
        textMoney.text = "$ " + money.ToString();
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("Merge", true);
        }
        else
        {
            animator.SetBool("Merge", false);
        }
        rb.AddForce(transform.forward * movementSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotSpeed);

    }
    private void Update()
    {
        if(hp<=0)
        {
            //animator.SetBool("Cade", true);
        }
        textMoney.text = "$ " + money.ToString();
        for (int i = 2; i > hp - 1; i--)
        {
            if (hp < 0)
                break;
            inimi[i].sprite = inimiSprite[1];
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool activ = !inventory.activeSelf;
            inventory.SetActive(activ);
            inventoryAdaos.SetActive(activ);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
            invetSelect = 9;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            invetSelect = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            invetSelect = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            invetSelect = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            invetSelect = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            invetSelect = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            invetSelect = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            invetSelect = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8))
            invetSelect = 7;
        if (Input.GetKeyDown(KeyCode.Alpha9))
            invetSelect = 8;

        if (Input.GetKeyDown(KeyCode.G))
        {
            invent.InvetoryRemove(invetSelect);
        }

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward* maxDistance + transform.up * 2.6f, out hit))
        {
            if (hit.collider.gameObject.tag == "item")
            {
                Item i = hit.collider.gameObject.GetComponent<Item>();
                Destroy(hit.collider.gameObject);
                invent.InvetoryAdd(i.itemIndex);
                money = money - i.cost;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ataca", true);
            atack = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Lovitura") && animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1.0f)
        {
            animator.SetBool("Ataca", false);
            atack = false;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag == "proiectil")
        {
            hp--;
            Destroy(other.collider.gameObject);
        }
    }


}
