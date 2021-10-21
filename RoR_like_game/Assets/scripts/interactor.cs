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
    public Vector3 chestPosition;
    public Vector3 itemSpawnPos;
    public float chestY;
    public float chestZ; 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        chestPosition = chest.transform.position;
        chestY = chestPosition.y + 1f;
        chestZ = chestPosition.z + 1f;
        itemSpawnPos = new Vector3(chestPosition.x,chestY,chestZ);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50 , interactableLayerMask)){
            if (Input.GetKeyDown(KeyCode.E)){
                    GameObject item = Instantiate(attackItem, itemSpawnPos, Quaternion.identity);
            }
        }
    }
}
