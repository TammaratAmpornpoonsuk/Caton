using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject first;
        [SerializeField] private GameObject second;
        [SerializeField] private GameObject playAgain;
        [SerializeField] private GameObject end;
        [SerializeField] private int timeToLoadNext;
        
        //playAgain.SetActive(true);
        //end.SetActive(true);
        // Start is called before the first frame update
        void Start()
        {
            first.SetActive(true);
            second.SetActive(false);
            StartCoroutine(LoadNext());
        }

        IEnumerator LoadNext()
        {
            yield return new WaitForSeconds(timeToLoadNext);
            first.SetActive(false);
            second.SetActive(true);
            playAgain.SetActive(true);
            end.SetActive(true);
        }
    }
}
