using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Spike : MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<HealthSystem>().PlayerTakeDamage(damage);
            }
        }
    }
}
