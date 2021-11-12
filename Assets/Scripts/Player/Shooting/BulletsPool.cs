using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Player.Shooting
{
    public class BulletsPool : GenericPool<Bullet>
    {
        public Bullet Spawn(Vector3 position, Quaternion rotation)
        {
            var bullet = Get();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
    }
}