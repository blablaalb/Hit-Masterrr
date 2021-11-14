using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Player
{
    using Managers;
    public class PlayerAnimationCallbacks : MonoBehaviour
    {
        public void OnDanceFinished()
        {
            LevelManager.Instance.OnLevelPassed();
        }
    }
}