using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caton
{
    public class SoundManager : MonoBehaviour
    {
        public enum SoundName
        {
            BGM,
            PlayerAttack,
            MeleeAttack,
            MageAttack,
            PlayerTakeDamage,
            Dash,
            CollectItem,
            Button,
            EnemyTakeDamage
        }

        [SerializeField] private Sound[] sounds;

        public static SoundManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Play(SoundName name)
        {
            Sound sound = GetSound(name);
            if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.clip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.loop = sound.loop;
            }
        
            sound.audioSource.Play();
        }

        Sound GetSound(SoundName name)
        {
            return Array.Find(sounds, s => s.soundName == name);
        }
    }
}
