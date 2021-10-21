using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{//Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;
    public GameObject item;
    void Update()
    {
        //Checks if the player is in the collider and also if the key is pressed.
        if(isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            //personalized code can go in here when activated.
            Debug.Log("Interact");
            Destroy(item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if(other.tag == "Player")
        {
            //turns on interactivity 
            isInteractable = true;
            Destroy(item);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //compares the tag of the object exiting this collider.
        if(other.tag == "Player")
        {
            //turns off interactivity 
            isInteractable = false;
        }
    }
}
