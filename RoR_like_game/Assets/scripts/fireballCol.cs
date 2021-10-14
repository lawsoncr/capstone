using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballCol : MonoBehaviour
{
    public GameObject fireb;
    public GameObject target;
    public float fireDamage = 5f;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player"); 
    }
    void OnTriggerEnter (Collider col){
        if(col.gameObject.tag == "Player"){
            target.GetComponent<ThirdPersonMovement>().DamagePlayer(fireDamage);
            Destroy(fireb);
        }
        if(col.gameObject.tag == "mapStuff"){
            Destroy(fireb);
        }
        
    }
}
