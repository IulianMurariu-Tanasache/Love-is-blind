using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject usa;
    public bool canOpen , open;
    public GameObject[] hazard = new GameObject[1];
    public float x, y, z;
    public float spawnWait;
    public GameObject player;
    public Player pulic;
    public int diff;
    public GameObject[] item = new GameObject[1];
    public int index;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    public GameObject cufar;
    public Vector3[] spawnsEnemies = new Vector3[8];
    public GameObject camer;
    public CameraFollow camerF;

    private void Start()
    {
        open = false ;
        canOpen = true;
        player = GameObject.FindWithTag("player");
        pulic = player.GetComponent<Player>();
        camer = GameObject.FindWithTag("MainCamera");
        camerF = camer.GetComponent<CameraFollow>();

    }
    private void Update()
    {
        if(pulic.nrEnemies <= 0)
        {
            //open = false;
            usa.transform.position = new Vector3(usa.transform.position.x, -12.2f, usa.transform.position.z);
            //canOpen = false;
            camerF.cameraEnter = false;
            pulic.rotSpeed = 100f;
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player" && canOpen == true)
        {
            diff = Random.Range(1, 8);
            pulic.nrEnemies = diff;
            pulic.rotSpeed = 250f;
            usa.transform.position = new Vector3(usa.transform.position.x, 0.5f, usa.transform.position.z);
            canOpen = false;
            open = false;
            camerF.cameraEnter = true;
            camerF.pos = usa.transform.position + transform.up * 15f + transform.forward * -2f;
            StartCoroutine(SpawnWaves());
        }

    }

    IEnumerator SpawnWaves()
    {
        
        while (diff > 0)
        {
            int random = Random.Range(0, spawnsEnemies.Length - 1);
            Vector3 spawnPosition = new Vector3(usa.transform.position.x, y, usa.transform.position.z + 0.5f) + spawnsEnemies[random];
                Quaternion spawnRotation = Quaternion.identity;
                int hazardIndex = Random.Range(0, hazard.Length - 1);
                Instantiate(hazard[hazardIndex], spawnPosition, spawnRotation);
                diff--;
                yield return new WaitForSeconds(spawnWait);
        }

        spawnPosition = new Vector3(usa.transform.position.x - 14f, 0f, usa.transform.position.z);
        spawnRotation.eulerAngles = new Vector3(0f,90f,0);
        index = Random.Range(0, item.Length - 1);
        Instantiate(cufar, spawnPosition, spawnRotation);
        Instantiate(item[index], spawnPosition + Vector3.up * 1.5f, spawnRotation);
        pulic.itemSpawed = index;
       
       
    }
}

