using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class StoryController : MonoBehaviour
    {
        [SerializeField] private GameObject first;
        [SerializeField] private GameObject second;
        [SerializeField] private GameObject third;
        [SerializeField] private string _nextSceneName;
        [SerializeField] private int timeToLoadNext;
        // Start is called before the first frame update
        void Start()
        {
            first.SetActive(true);
            second.SetActive(false);
            third.SetActive(false);

            StartCoroutine(LoadNext());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(_nextSceneName);
            }
        }

        IEnumerator LoadNext()
        {
            yield return new WaitForSeconds(timeToLoadNext);
            first.SetActive(false);
            second.SetActive(true);

            yield return new WaitForSeconds(timeToLoadNext);
            second.SetActive(false);
            third.SetActive(true);

            yield return new WaitForSeconds(timeToLoadNext);
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
