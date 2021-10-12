using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject target;
    //Attack variables
    public float timeBetweenAttacks;
    public float enemyDamage = 15f;
    bool attackedAlready;
    public GameObject fireball;
    public float attackRange = 6f;
    public float fireballSpeed;
    public bool playerInAttackRange;
    public float health;

    void Awake()
    {
        //Refrence to player
        player = GameObject.Find("ThirdPersonPlayer").transform;
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfPlayer is in attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange) AttackPlayer();

        ChasePlayer();
    }

    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
        transform.LookAt(player);

        if(!attackedAlready){
            
            GameObject projectile = Instantiate(fireball, transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * fireballSpeed;

            Destroy(projectile, 2f);

            Debug.Log("Attacked Player");
            attackedAlready = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack(){
        attackedAlready = false;
    }

    public void TakeDamage(float deductHealth){
        health -= deductHealth;

        if (health <= 0) { KillEnemy (); };
    }

    public void KillEnemy(){
        Destroy(gameObject);
    }
}
