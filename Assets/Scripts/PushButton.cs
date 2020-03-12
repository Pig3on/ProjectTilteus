using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    Animator animator;
    void Awake() {
        animator = this.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            animator.SetBool("isPressed", true);
        }
       
    }
    void OnCollisionExit(Collision collision)
    {  
        if(collision.gameObject.CompareTag("Player")){
            animator.SetBool("isPressed", false);
        }
    }
}
