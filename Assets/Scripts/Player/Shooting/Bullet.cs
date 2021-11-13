using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Player.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private bool _fire;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _damage;
        private bool _hit;
        private BulletsPool _bulletsPool;

        internal void Awake()
        {
            _bulletsPool = FindObjectOfType<BulletsPool>();
        }

        public void Fire()
        {
            _fire = true;
        }

        internal void Update()
        {
            if (_fire)
            {
                transform.position +=  transform.forward * _speed * Time.deltaTime;
            }
        }

        internal void OnTriggerEnter(Collider other)
        {
            if (!_hit)
            {
                _hit = true;
                var shootable = other.GetComponentInParent<ISHootable>();
                if (shootable != null)
                {
                    shootable.OnShot(_damage, transform.forward);
                }
                gameObject.SetActive(false);
                _bulletsPool.Add(this);
                _hit = false;
            }
        }
    }
}