using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class CrystalFlower : MonoBehaviour
    {
        [SerializeField] private Collider2D crystalFlower;
        [SerializeField] private GameObject playAgain;
        [SerializeField] private GameObject end;
        [SerializeField] private string _nextSceneName;
        
        // Start is called before the first frame update
        void Start()
        {
            crystalFlower.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                crystalFlower.enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                //Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                //playAgain.SetActive(true);
                //end.SetActive(true);
                SceneManager.LoadScene(_nextSceneName);
                SoundManager.instance.Play(SoundManager.SoundName.CollectItem);
            }
        }
    }
}
