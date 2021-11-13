using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace Enemy
{
    public class SquadMember : MonoBehaviour
    {
        private Squad _squad;

        internal void Awake()
        {
            _squad = transform.parent.GetComponent<Squad>();
        }

        public void OnKilled()
        {
            _squad.OnMemberEliminated(this);
        }
    }
}