using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask = 9;
    UnityEvent onInteract;
    public GameObject attackItem;
    public GameObject chest;
    public GameObject player;
    public GameObject spawnName;
    public GameObject uniqueChest;
    public Vector3 chestPosition;
    public Vector3 playerPosition;
    public Vector3 itemSpawnPos;
    public float chestY;
    public float chestZ; 
    public bool accessChest;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        playerPosition = player.transform.position;
        chestPosition = chest.transform.position;
        chestY = playerPosition.y + 1f;
        chestZ = playerPosition.z - 1f;
        itemSpawnPos = new Vector3(playerPosition.x,chestY,chestZ);
        

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 15 , interactableLayerMask)){
            if ((playerPosition.z - chestPosition.z) < 5){
                if (Input.GetKeyDown(KeyCode.E)){
                    GameObject item = Instantiate(attackItem, itemSpawnPos, Quaternion.identity);
                    Debug.Log(uniqueChest.name);
                    
                }
            }
        }
    }
}
