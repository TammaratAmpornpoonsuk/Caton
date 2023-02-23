using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] int health;
        [SerializeField] private Collider2D enemyCollider2D;
        void Update()
        {
            if (health <= 0)
            {
                enemyCollider2D.enabled = false;
                animator.SetBool("isDead",true);
                Destroy(gameObject,1);
            }
        }
        
        public void EnemyTakeDamage(int damage)
        {
            health -= damage;
            SoundManager.instance.Play(SoundManager.SoundName.EnemyTakeDamage);
        }
    }
}
