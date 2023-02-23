using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class Fireball : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;
        [SerializeField] private int timeToDestroy;

        private Vector2 directionToPlayer;
        private Transform player;
        
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            Destroy(gameObject,timeToDestroy);
        }
        
        void Update()
        {
                transform.position += (Vector3)directionToPlayer * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthSystem>().PlayerTakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
