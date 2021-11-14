using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Collections;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using UnityEngine.UI;

namespace Enemy
{
    using Physics;
    using Common;
    public class Controller : MonoBehaviour, Player.Shooting.ISHootable
    {
        private Animator _animator;
        private AnimationClip[] _animClips;
        [SerializeField]
        private float _maxHealth;
        private float _health;
        private Ragdoll _ragdoll;
        private bool _alive;
        private Slider _slider;
        [SerializeField]
        private AudioClip[] _bulletImpactClips;
        private AudioSource _audSource;

        internal void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animClips = _animator.runtimeAnimatorController.animationClips;
            _ragdoll = GetComponent<Ragdoll>();
            _health = _maxHealth;
            _alive = true;
            _slider = GetComponentInChildren<Slider>();
            _audSource = GetComponent<AudioSource>();
        }

        internal void Start()
        {
            RandomIdle();
        }

        private void RandomIdle()
        {
            var indx = Random.Range(0, 3);
            var idle = _animClips[indx].name;
            _animator.Play(idle);
        }

        public void OnShot(float damage)
        {
            if (_alive)
            {
                PlayBulletImpactAudio();
                float newHealth = _health - damage;
                _health = Mathf.Max(newHealth, 0f);
                _slider.value = _health / _maxHealth;
                if (newHealth <= 0f) OnDied();
            }
        }

        public void OnShot(float damage, Vector3 direction)
        {
            if (_alive)
            {
                OnShot(damage);
                Utils.Instance.RandomizeSeed();
                float multiplier = Random.Range(-1, 1);
                Utils.Instance.RandomizeSeed();
                direction.x = Random.Range(-1, 2);
                direction.y *= multiplier;
                Utils.Instance.RandomizeSeed();
                direction.z = Random.Range(-1, 1);
                Utils.Instance.RandomizeSeed();
                direction.x *= Random.Range(50,100 );
                direction.y *= Random.Range(90, 130);
                if (!_alive) _ragdoll.AddForce(direction);
            }
        }

        private void OnDied()
        {
            _ragdoll.EanbleRagdoll();
            _alive = false;
            GetComponent<SquadMember>().OnKilled();
            StartCoroutine(HealthSliderFadeoutCoroutine());
        }

        private IEnumerator HealthSliderFadeoutCoroutine()
        {
            yield return new WaitForSeconds(1f);
            _slider.gameObject.SetActive(false);
        }

        private void PlayBulletImpactAudio()
        {
            int indx = Random.Range(0, _bulletImpactClips.Length);
            _audSource.clip = _bulletImpactClips[indx];
            _audSource.Play();
        }
    }
}