using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using System.Collections;
using UnityEngine.AI;

namespace Player.Navigation
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Locomotion : MonoBehaviour
    {
        private Waypoint[] _waypoints;
        private int _nextWaypointIndx = 0;
        private NavMeshAgent _navAgent;
        private Animator _animator;

        internal void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _waypoints = FindObjectsOfType<Waypoint>();
            _waypoints = _waypoints.OrderBy(x => x.Index).ToArray();
            _animator = GetComponentInChildren<Animator>();
        }

        internal void Start()
        {
            Move();
        }

        public void Move()
        {
            var destination = NextWayPoint().Position;
            _navAgent.SetDestination(destination);
            _animator.Play("run");
            StartCoroutine(WaitDestionationReachedCoroutine());
        }

        private Waypoint NextWayPoint()
        {
            var waypoint = _waypoints[_nextWaypointIndx];
            _nextWaypointIndx++;
            return waypoint;
        }

        private IEnumerator WaitDestionationReachedCoroutine()
        {
            var distance = Vector3.Distance(transform.position, _navAgent.destination);
            var wait = new WaitForEndOfFrame();
            while (distance > 0.5f)
            {
                yield return wait;
                distance = Vector3.Distance(transform.position, _navAgent.destination);
            }
            OnDestinationReached();
        }

        private void OnDestinationReached()
        {
            _animator.CrossFade("pistol-idle", 0.7f);
        }
    }
}