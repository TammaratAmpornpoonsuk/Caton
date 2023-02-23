using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class MaxHealthDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI maxHPText;
        [SerializeField] private HealthSO _healthSo;

        private void Update()
        {
            Scene levelOneScene = SceneManager.GetSceneByName("Level 1");
            Scene levelTwoScene = SceneManager.GetSceneByName("Level 2");
            if (levelOneScene.isLoaded || levelTwoScene.isLoaded)
            {
                maxHPText.text = $"Max HP : {_healthSo.MaxHP}";
            }
        }

        public void MaxHealth(int increment)
        {
            maxHPText.text = $"Max HP : {increment}";
        }
    }
}
