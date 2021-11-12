using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Player.Shooting
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField]
        private Transform _barrel;
        private BulletsPool _bulletsPool;
        private Camera _camera;
        [SerializeField]
        private float _maxShotDistance;

        internal void Awake()
        {
            _camera = Camera.main;
            _bulletsPool = FindObjectOfType<BulletsPool>();
        }

        public void Shoot(Vector2 screenPos)
        {
            var distance = _maxShotDistance + Vector3.Distance(_camera.transform.position, _barrel.position);
            var pos = new Vector3(screenPos.x, screenPos.y, distance);
            var ray = _camera.ScreenPointToRay(pos);
            RaycastHit rayHit;
            bool hit = Physics.Raycast(ray, out rayHit);
            Bullet bullet = null;
            if (hit)
                bullet = _bulletsPool.Spawn(_barrel.position, Quaternion.LookRotation(rayHit.point - _barrel.position));
            else
            {
                var worldPoint = _camera.ScreenToWorldPoint(pos);
                bullet = _bulletsPool.Spawn(_barrel.position, Quaternion.LookRotation(worldPoint - _barrel.position));
            }
            bullet.Fire();
        }

        internal void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(Input.mousePosition);
            }
        }
    }
}