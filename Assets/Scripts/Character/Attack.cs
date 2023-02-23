using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private LayerMask isEnemy;
        [SerializeField] private Transform attackPos;
        [SerializeField] private HealthSO _healthSO;
        
        [SerializeField] private float range;
        [SerializeField] private float startCooldownAttack;
        [SerializeField] private int damage;
        private float cooldownAttack;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (cooldownAttack <= 0 && Time.timeScale != 0 && _healthSO.MaxHP != 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("isAttacking",true);
                    SoundManager.instance.Play(SoundManager.SoundName.PlayerAttack);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, isEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<TakeDamage>().EnemyTakeDamage(damage);
                    }
                    cooldownAttack = startCooldownAttack;
                }
                else
                {
                    animator.SetBool("isAttacking",false);
                }
            }
            else
            {
                cooldownAttack -= Time.deltaTime;
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPos.position,range);
        }
    }
}
