using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Player.Navigation
{
    public class Waypoint : MonoBehaviour
    {
        public int Index;
        public Vector3 Position => transform.position;
    }
}