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

    public float attackRange = 4.0f;
    public bool playerInAttackRange;
    public float health;
    public Animator animator;

    public bool isDead = false;


    void Awake()
    {
        //Refrence to player
        player = GameObject.Find("ThirdPersonPlayer").transform;
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) {
            //CheckIfPlayer is in attack range
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (playerInAttackRange) AttackPlayer();

            ChasePlayer();
        }
    }

    private void ChasePlayer() {
        if (!isDead) {
            agent.SetDestination(player.position);
            animator.SetBool("whaleRun", true);
        }
    }

    private void AttackPlayer() {
        if (!isDead) {
            transform.LookAt(player);
            if (!attackedAlready) {
                    if (playerInAttackRange) {
                        target.GetComponent<ThirdPersonMovement>().DamagePlayer(enemyDamage);
                        Debug.Log("Attacked Player");
                        attackedAlready = true;
                        Invoke(nameof(ResetAttack), timeBetweenAttacks);
                        animator.SetBool("whaleAttack", true);
                }
            }
        }
    }
    private void ResetAttack() {
        attackedAlready = false;
        animator.SetBool("whaleAttack", false);
        animator.SetBool("whaleRun", true);
    }

    public void TakeDamage(float deductHealth) {
         if (!isDead) {
            health -= deductHealth;
            if (health <= 0) KillEnemy ();
        }
    }

    public void KillEnemy() {
        isDead = true;
        animator.SetBool("whaleDead", true);
        animator.SetBool("whaleRun", false);
        Destroy(gameObject, 4.0F); // deletes the enemy after 4 seconds to reduce lag
    }
}
