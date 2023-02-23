using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Caton
{
    public class HealthManager : Singleton<HealthManager>
    {
        private int maxHP;
        private int currentHP;
        [SerializeField] private UnityEvent<int> onMaxHealthUpdate;
        [SerializeField] private UnityEvent<int> onCurrentHealthUpdate;

        public void UpdateMaxHp(int max)
        {
            maxHP = max;
            onMaxHealthUpdate?.Invoke(maxHP);
        }

        public void UpdateCurrentUp(int current)
        {
            currentHP = current;
            onCurrentHealthUpdate?.Invoke(currentHP);
        }
    }
}
