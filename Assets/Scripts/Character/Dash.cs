using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] private float dashSpeed;
        [SerializeField] private float startDashTime;
        [SerializeField] private float resetTimer;
        
        private Rigidbody2D rb;
        private float dashTime;
        
        private int tapD;
        private int tapA;
        private int direction;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
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
                        //transform.position += Vector3.right * dashSpeed;
                        rb.velocity = Vector2.right * dashSpeed;
                        SoundManager.instance.Play(SoundManager.SoundName.Dash);
                    }
    
                    if (direction == 2)
                    {
                        //transform.position += Vector3.left * dashSpeed;
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
