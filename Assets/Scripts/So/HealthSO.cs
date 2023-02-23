using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    [CreateAssetMenu (menuName = "ScriptableObject/Health")]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] private int _maxHP;
        [SerializeField] private int _currentHP;

        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }

        public int CurrentHP
        {
            get { return _currentHP; }
            set { _currentHP = value; }
        }
    }
}
