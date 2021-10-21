using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject newPlayer;
    public GameObject newCam;
    public Vector3 spawnPosition;
    void Start()
    {
        SpawnPlay();
    }

    private void SpawnPlay(){
        //Spawn enemy at random range
        spawnPosition = new Vector3(30f,2f,30f);
        newPlayer = Instantiate(player, spawnPosition, Quaternion.identity);
        newCam = Instantiate(newCam, spawnPosition, Quaternion.identity);  
    }
}
