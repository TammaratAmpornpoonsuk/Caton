using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class SetHP : MonoBehaviour
    {
        [SerializeField] private HealthSO _healthSO;
        [SerializeField] private int maxHP;
        void Start()
        {
            Time.timeScale = 1;
            _healthSO.MaxHP = maxHP;
            _healthSO.CurrentHP = _healthSO.MaxHP;
        }
    }
}
