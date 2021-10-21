using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    public float plusAttack = 15f;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if(other.tag == "Player")
        {
            player.GetComponent<GunScript>().playerAttack(plusAttack);
            Destroy(item);
        }
    }
}
