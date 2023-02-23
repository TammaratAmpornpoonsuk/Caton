using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caton
{
    public class CurrentHealthDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentHPText;
        [SerializeField] private HealthSO _healthSo;

        private void Update()
        {
            Scene levelOneScene = SceneManager.GetSceneByName("Level 1");
            Scene levelTwoScene = SceneManager.GetSceneByName("Level 2");
            if (levelOneScene.isLoaded || levelTwoScene.isLoaded)
            {
                currentHPText.text = $"HP : {_healthSo.CurrentHP}";
            }
        }

        public void CurrentHealth(int increment)
        {
            currentHPText.text = $"HP : {increment}";
        }
    }
}
