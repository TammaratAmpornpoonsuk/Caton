using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private LayerMask ground;
        [SerializeField] private Transform feetPos;
        
        [SerializeField] private float jumpForce;
        [SerializeField] private float checkRadius;
        [SerializeField] private int jumpValue;
        
        private Rigidbody2D rb;
        private bool isGrounded;
        private int doubleJump;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            doubleJump = jumpValue;
        }

        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        }

        void Update()
        {
            if (isGrounded == true)
            {
                doubleJump = jumpValue;
            }
    
            if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping",true);
                doubleJump--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && doubleJump == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping",true);
            }
        }
    }
}
