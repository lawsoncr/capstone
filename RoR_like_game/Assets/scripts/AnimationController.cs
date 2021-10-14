using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // get animator instance
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Format for the animation control, if a key is pressed, then allow specific animation to play
        // *** Running Logic ***
        bool notRun = Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D);
        bool notSprint = Input.GetKeyUp(KeyCode.LeftShift);
        // If Running, play running animation
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) == true) {
            animator.SetBool("isRunning", true);
        }
        // if not running, play idle animation
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) != true) {
            animator.SetBool("isRunning", false);
            animator.SetBool("isSprinting", false);
            if (notRun && notSprint) {
                animator.SetBool("isIdle", true);
            }
        }


        // *** Sprinting Logic ***//
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            animator.SetBool("isSprinting", true);
            animator.SetBool("isIdle", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            animator.SetBool("isSprinting", false);
            if (notSprint && notRun) {
            animator.SetBool("isIdle", true);
            }
        }

    }


}