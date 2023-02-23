using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Caton
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private float speed;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float startDashTime;
        [SerializeField] private float resetTimer;
        
        private Rigidbody2D rb;
        private Vector2 lowerLeft;
        private Vector2 uperRight;
        private float dashTime;
        private float moveInput;
        private int tapD;
        private int tapA;
        private int direction;
        
        void Start()
        {
            dashTime = startDashTime;
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Move();
            Dash();
        }
        
        void CreateBoundary()
        {
            lowerLeft = _camera.ViewportToWorldPoint(new Vector2(0,0));
            uperRight = _camera.ViewportToWorldPoint(new Vector2(1, 1.06f));

            Vector2 extends = sprite.bounds.extents;
            lowerLeft += extends;
            uperRight -= extends;
        }
        
        Vector3 CheckBoundary(Vector3 pos)
        {
            pos.x = Mathf.Clamp(pos.x, lowerLeft.x, uperRight.x);
            pos.y = Mathf.Clamp(pos.y, lowerLeft.y, uperRight.y);
            return pos;
        }

        void Move()
        {
            if (Time.timeScale != 0)
            {
                moveInput = Input.GetAxisRaw("Horizontal");
            }
            animator.SetFloat("Run",Math.Abs(moveInput));
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (moveInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (moveInput < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            CreateBoundary();
            transform.position = CheckBoundary(transform.position);
        }
        
        void Dash()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(ResetTapTimes());
                tapD++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(ResetTapTimes());
                tapA++;
            }
    
            if (direction == 0)
            {
                if (tapD >= 2)
                {
                    direction = 1;
                    tapD = 0;
                }
    
                if (tapA >= 2)
                {
                    direction = 2;
                    tapA = 0;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                        SoundManager.instance.Play(SoundManager.SoundName.Dash);
                    }
    
                    if (direction == 2)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                        SoundManager.instance.Play(SoundManager.SoundName.Dash);
                    }
                }
            }
            
            IEnumerator ResetTapTimes()
            {
                yield return new WaitForSeconds(resetTimer);
                tapD = 0;
                tapA = 0;
            }
        }
    }
}
