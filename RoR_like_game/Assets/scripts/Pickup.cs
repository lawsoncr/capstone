using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{//Flag used to tell if the object can be interacted with or not.
    public bool isInteractable = false;
    public GameObject item;
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
