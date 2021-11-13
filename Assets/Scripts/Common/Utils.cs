using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Common
{
    public class Utils : MonoBehaviour
    {
        private static Utils _instance;
        public static Utils Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("Utils");
                    _instance = go.AddComponent(typeof(Utils)) as Utils;
                }
                return _instance;
            }
        }

        public void RandomizeSeed()
        {
            Random.InitState((int)(DateTime.Now.Ticks / Time.deltaTime * 0.1f * System.Environment.TickCount) - Random.seed);
        }
    }
}
