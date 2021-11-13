using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using Managers;

namespace Enemy
{
    public class Squad : MonoBehaviour
    {
        [SerializeField]
        private SquadMember[] _members;
        private int _alive;

        internal void Awake()
        {
            if (_members == null || _members.Length <= 0) _members = GetComponentsInChildren<SquadMember>();
            _alive = _members.Length;
        }

        public void OnMemberEliminated(SquadMember member)
        {
            _alive--;
            if (_alive <= 0) LevelManager.Instance.OnSquadEliminated(this);
        }
    }
}