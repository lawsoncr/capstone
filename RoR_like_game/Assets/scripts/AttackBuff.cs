using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour
{
    public GameObject item;
    public float plusAttack = 15f;
    public GameObject gun;
    // Start is called before the first frame update
    void Awake()
    {
        gun = GameObject.FindGameObjectWithTag("Gun"); 
    }

    void OnTriggerEnter(Collider other)
    {
        //Compares the tag of the object entering this collider.
        if(other.CompareTag("Player"))
        {
            GunScript gunDamage = gun.GetComponent<GunScript>();
            gunDamage.damageEnemy += 15f;
            Destroy(item);
        }
    }
}
