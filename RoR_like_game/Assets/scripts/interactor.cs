using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask = 9;
    public GameObject attackItem;
    public GameObject speedBuff;
    public GameObject text;
    public GameObject chest;
    public GameObject toInstantiate;
    public GameObject player;
    
    public Vector3 chestPosition;
    public Vector3 playerPosition;
    public Vector3 itemSpawnPos;
    public float chestY;
    public float chestZ; 
    public int num;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.FindGameObjectWithTag("text");
        
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
               
        text.SetActive(false);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 15 , interactableLayerMask)){
            if ((playerPosition.z - chestPosition.z) < 5){
                text.SetActive(true);
                
                if (Input.GetKeyDown(KeyCode.E)){
                    LootDrop(); 
                    
                }
            }
        }
    }
    void LootDrop(){
        num = Random.Range (0, 3);

        if (num == 0 || num == 2) {
            toInstantiate = speedBuff;
        } 
        if (num == 1 || num == 3) {
            toInstantiate = attackItem;
        }
        GameObject item = Instantiate(toInstantiate, itemSpawnPos, Quaternion.identity);
    }
    
}
