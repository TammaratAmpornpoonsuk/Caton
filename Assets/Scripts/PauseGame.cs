using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private GameObject returnToMainMenu;
        [SerializeField] private GameObject gameOver;
        
        [SerializeField] private TextMeshProUGUI resumeText;
        [SerializeField] private TextMeshProUGUI backText;
        
        [SerializeField] private string _nextSceneName;
        
        private bool pause;
        
        // Start is called before the first frame update
        void Start()
        {
            returnToMainMenu.SetActive(false);
            gameOver.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                returnToMainMenu.SetActive(true);
                gameOver.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pause = !pause;
                    Pause();
                }
                
                returnToMainMenu.SetActive(false);
                gameOver.SetActive(false);
            }
        }
        
        void Pause()
        {
            if (pause)
            {
                resumeText.text = "RESUME";
                backText.text = "BACK";
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                resumeText.text = null;
                backText.text = null;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void ResumeButton()
        {
            if (pause)
            {
                pause = false;
                Pause();
                SoundManager.instance.Play(SoundManager.SoundName.Button);
            }
        }
        
        public void BackButton()
        {
            if (pause)
            {
                pause = false;
                Pause();
                //LoadingScreenController.instance.LoadNextScene(_nextSceneName);
                SceneManager.LoadScene(_nextSceneName);
                Cursor.lockState = CursorLockMode.None;
                SoundManager.instance.Play(SoundManager.SoundName.Button);
            }
        }

        public void ReturnToMainMenuButton()
        {
            //LoadingScreenController.instance.LoadNextScene(_nextSceneName);
            SceneManager.LoadScene(_nextSceneName);
            Cursor.lockState = CursorLockMode.None;
            SoundManager.instance.Play(SoundManager.SoundName.Button);
        }
    }
}
