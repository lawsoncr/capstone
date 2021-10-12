using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject newEnemy;
    public Vector3 spawnPosition;
    public int enemyCount;
    public GameObject player;
    public Vector3 playerPos;
    public float playerX;
    public float playerZ;
    public float ranX;
    public float ranZ;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 3f);
    }

    private void SpawnEnemy(){
        //Convert Player position to xyz cordinates
        playerPos = player.transform.position;
        playerX = playerPos.x;
        playerZ = playerPos.z;

        //grab random values in range of player
        ranX = Random.Range(playerX - 20, playerX + 20);
        ranZ = Random.Range(playerZ - 20, playerZ + 20);

        //Spawn enemy at random range
        spawnPosition = new Vector3(ranX,0f,ranZ);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            
          
    }
    
    
}
