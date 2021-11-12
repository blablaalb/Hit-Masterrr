using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Enemy
{
    public class Controller : MonoBehaviour
    {
        private Animator _animator;
        private AnimationClip[] _animClips;

        internal void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animClips = _animator.runtimeAnimatorController.animationClips;
        }

        internal void Start()
        {
            RandomIdle();
        }

        private void RandomIdle()
        {
            var indx = Random.Range(0, 3);
            var idle =  _animClips[indx].name;
            _animator.Play(idle);
        }
    }
}