using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class NextScene : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer doorClose;
        [SerializeField] private SpriteRenderer doorOpen;
        [SerializeField] private Collider2D door;
        [SerializeField] private string _nextSceneName;

        private PlayerController _player;

        private void Start()
        {
            doorClose.enabled = true;
            doorOpen.enabled = false;
            door.enabled = false;
        }

        private void Update()
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                doorClose.enabled = false;
                doorOpen.enabled = true;
                door.enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // check if we are colliding with the player
            if (col.TryGetComponent(out _player))
            {
                // load the next scene
                if (doorOpen)
                {
                    //LoadingScreenController.instance.LoadNextScene(_nextSceneName);
                    SceneManager.LoadScene(_nextSceneName);
                }
            }
        }
    }
}
