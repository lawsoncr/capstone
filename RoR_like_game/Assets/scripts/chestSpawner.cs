using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestSpawner : MonoBehaviour
{
    public GameObject chest;
    public GameObject newChest;
    public Vector3 spawnPosition;
    public int chestCount = 0;
    public GameObject spawner;
    public Vector3 spawnerPos;
    public float spawnerX;
    public float spawnerZ;
    public float ranX;
    public float ranZ;
    public int nextNumber = 0;

    void Start()
    {   
        while(chestCount <= 15){
            InvokeRepeating("SpawnChest", 0f, 0f);
            chestCount ++;   
        } 
        
    }

    private void SpawnChest(){
        //Convert Player position to xyz cordinates
        spawnerPos = spawner.transform.position;
        spawnerX = spawnerPos.x;
        spawnerZ = spawnerPos.z;

        //grab random values in range of player
        ranX = Random.Range(spawnerX - 150, spawnerX + 150);
        ranZ = Random.Range(spawnerZ - 150, spawnerZ + 150);

        //Spawn chest at random range
        spawnPosition = new Vector3(ranX,5f,ranZ);
        newChest = Instantiate(chest, spawnPosition, Quaternion.identity);
        newChest.name = "chest"+nextNumber;
        nextNumber++;
            
          
    }
}
