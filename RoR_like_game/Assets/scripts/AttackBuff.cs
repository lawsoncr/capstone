using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour
{
    public GameObject item;
    public GameObject gun;
    public float plusAttack = 15f;
    void Awake()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
    }

    void Update()
    {
        //Compares the tag of the object entering this collider.
        if(item == null){
            gun.GetComponent<GunScript>().playerAttack(plusAttack);
        }
    }
}
