using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bossSpawner : MonoBehaviour
{

    public GameObject boss;
    public GameObject pillar;
    public GameObject player;
    public Vector3 pillarPosition;
    public Vector3 playerPosition;
    public Vector3 bossSpawnPos;
    public float pillarY;
    public float pillarZ;
    public float pillarX;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        pillarPosition = pillar.transform.position;
        pillarY = pillarPosition.y + 1f;
        pillarZ = pillarPosition.z - 10f;
        pillarX = pillarPosition.x + 10f;
        bossSpawnPos = new Vector3(pillarX, pillarY, pillarZ);

        if ((playerPosition.z - pillarPosition.z) < 5){
            GameObject bossEnemy = Instantiate(boss, bossSpawnPos, Quaternion.identity);        
        }
    }
}
