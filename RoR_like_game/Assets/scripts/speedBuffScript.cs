using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBuffScript : MonoBehaviour
{
    public GameObject item;
    public float plusSpeed;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if(other.CompareTag("Player"))
        {
            ThirdPersonMovement plusSpeed = player.GetComponent<ThirdPersonMovement>();
            plusSpeed.speed += 2f;
            plusSpeed.sprintSpeed += 4f;
            Destroy(item);
        }
    }
}
