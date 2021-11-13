using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Common
{
    public class Ricochet : MonoBehaviour, Player.Shooting.ISHootable
    {
        [SerializeField]
        private AudioClip[] _audClips;
        private AudioSource _audSource;

        internal void Awake()
        {
            _audSource = FindObjectOfType<AudioSource>();
        }

        public void Play()
        {
            int indx = Random.Range(0, _audClips.Length);
            _audSource.PlayOneShot(_audClips[indx]);
        }

        public void OnShot(float damage)
        {
            Play();
        }

        public void OnShot(float damage, Vector3 direction)
        {
            Play();
        }
    }
}