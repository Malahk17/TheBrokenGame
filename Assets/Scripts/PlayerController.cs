using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public Animator animator;
    public float speed = 5f;

    private Vector2 movement;
    private Vector2 velocity;
    private bool sitting = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!sitting)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("SitDown");
                sitting = true;
            }
        }
        else if (sitting && Input.GetKeyDown(KeyCode.Escape))
        {
            animator.SetTrigger("StandUp");
            sitting = false;
        }
        
    }

    void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + movement * (speed * Time.fixedDeltaTime));
    }
}
