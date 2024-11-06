using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace SaveAndManager
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")] 
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip background;
        [SerializeField] private AudioClip crashSfx;

        private void Start()
        {
            musicSource.clip = background;
            musicSource.Play();
        }

        private void Update()
        {
            if (!Application.isFocused)
            {
                musicSource.Stop();
            }
        }

        public void PlayCrashSfx()
        {
            if(sfxSource.isActiveAndEnabled)
                sfxSource.PlayOneShot(crashSfx);
        }

        public void DisableSfx()
        {
            sfxSource.gameObject.SetActive(false);
        }
    }
}
