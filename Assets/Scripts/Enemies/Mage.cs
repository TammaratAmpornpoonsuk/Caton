using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Mage : MonoBehaviour
    {
        [SerializeField] private Collider2D mageCollider2D;
        [SerializeField] private Transform frontStaff;
        [SerializeField] private GameObject fireball;
        
        [SerializeField] private float startCoolDownAttack;
        
        private Transform target;
        private float coolDownAttack;

        void Update()
        {
            if (target != null && mageCollider2D.enabled)
            {
                if (coolDownAttack <= 0)
                {
                    Instantiate(fireball, frontStaff.position, Quaternion.identity);
                    SoundManager.instance.Play(SoundManager.SoundName.MageAttack);
                    coolDownAttack = startCoolDownAttack;
                }
                else
                {
                    coolDownAttack -= Time.deltaTime;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                target = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                target = null;
            }
        }
    }
}
