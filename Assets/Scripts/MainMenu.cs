using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject start;
        [SerializeField] private GameObject exit;
        [SerializeField] private GameObject credit;
        [SerializeField] private GameObject back;
        [SerializeField] private GameObject member;
        [SerializeField] private string _nextSceneName;

        void Start()
        {
            SoundManager.instance.Play(SoundManager.SoundName.BGM);
            
            start.SetActive(true);
            exit.SetActive(true);
            credit.SetActive(true);
            
            back.SetActive(false);
            member.SetActive(false);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(_nextSceneName);
            SoundManager.instance.Play(SoundManager.SoundName.Button);
        }

        public void ExitGame()
        {
            Application.Quit();
            SoundManager.instance.Play(SoundManager.SoundName.Button);
        }

        public void Credit()
        {
            start.SetActive(false);
            exit.SetActive(false);
            credit.SetActive(false);
            
            back.SetActive(true);
            member.SetActive(true);
            SoundManager.instance.Play(SoundManager.SoundName.Button);
        }

        public void Back()
        {
            start.SetActive(true);
            exit.SetActive(true);
            credit.SetActive(true);
            
            back.SetActive(false);
            member.SetActive(false);
            SoundManager.instance.Play(SoundManager.SoundName.Button);
        }
    }
}
