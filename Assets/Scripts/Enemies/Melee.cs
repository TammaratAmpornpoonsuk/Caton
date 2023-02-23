using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Melee : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float startCoolDownAttack;
        
        private float coolDownAttack;

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (coolDownAttack <= 0)
                {
                    other.gameObject.GetComponent<HealthSystem>().PlayerTakeDamage(damage);
                    SoundManager.instance.Play(SoundManager.SoundName.MeleeAttack);
                    coolDownAttack = startCoolDownAttack;
                }
                else
                {
                    coolDownAttack -= Time.deltaTime;
                }
            }
        }
    }
}
