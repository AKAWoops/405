using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mark.Ballinger.GAM405
{
    
    public class SoundManager : MonoBehaviour
    {
        
        private static SoundManager _instance;
        public static SoundManager Instance { get { return _instance; } }

        [SerializeField]
        private List<AudioClip> _audioClips = new List<AudioClip>();

        [SerializeField]
        private List<AudioSource> _audioSources = new List<AudioSource>();

        protected void Awake()
        {
            _instance = this;
        }

        internal void PlayAudioClip(object coinSound)
        {
            throw new NotImplementedException();
        }

        
        /// Play the AudioClip by index.
        
        public void PlayAudioClip(int index)
        {
            PlayAudioClip(_audioClips[index]);
        }

        
        /// Play the AudioClip by reference.
        /// If all sources are occupied, nothing will play.
        
        public void PlayAudioClip(AudioClip audioClip)
        {
            foreach (AudioSource audioSource in _audioSources)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    return;
                }
            }
        }
    }
}