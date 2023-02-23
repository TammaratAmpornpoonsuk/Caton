using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private HealthSO _healthSO;
        
        private Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Health()
        {
            if (_healthSO.MaxHP > 2)
            {
                if (_healthSO.CurrentHP <= 0)
                {
                    if (_healthSO.MaxHP % 2 == 0)
                    {
                        _healthSO.MaxHP -= 3;
                    }
                    else
                    {
                        _healthSO.MaxHP -= 2;
                    }
                    _healthSO.CurrentHP = _healthSO.MaxHP;
                }
            }
            else if (_healthSO.MaxHP == 2)
            {
                if (_healthSO.CurrentHP <= 0)
                {
                    _healthSO.MaxHP -= 1;
                    _healthSO.CurrentHP = _healthSO.MaxHP;
                }
            }
            else if (_healthSO.MaxHP == 1)
            {
                if (_healthSO.CurrentHP <= 0)
                {
                    _healthSO.MaxHP = 0;
                    if (_healthSO.MaxHP <= 0)
                    {
                        animator.SetBool("isDead",true);
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        Destroy(gameObject,1);
                    }
                }
            }
            if (_healthSO.MaxHP == 0 && _healthSO.CurrentHP < 0)
            {
                _healthSO.CurrentHP = 0;
            }
        }
        
        public void PlayerTakeDamage(int damage)
        {
            _healthSO.CurrentHP -= damage;
            SoundManager.instance.Play(SoundManager.SoundName.PlayerTakeDamage);
            Health();
            
            HealthManager.Instance.UpdateMaxHp(_healthSO.MaxHP);
            HealthManager.Instance.UpdateCurrentUp(_healthSO.CurrentHP);
        }
    }
}
