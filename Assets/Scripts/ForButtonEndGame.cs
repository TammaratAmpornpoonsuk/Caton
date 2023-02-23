using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class ForButtonEndGame : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
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
