using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Enemy.Physics
{
    public class Ragdoll : MonoBehaviour
    {
        private Rigidbody[] _rigidBodies;
        private Animator _animator;

        public bool Enabled { get; private set; }

        internal void Awake()
        {
            _rigidBodies = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
            _animator = transform.GetChild(0).GetComponent<Animator>();
            DisableRagdoll();
        }


        public void EanbleRagdoll()
        {
            foreach (var rb in _rigidBodies)
            {
                rb.isKinematic = false;
            }
            _animator.enabled = false;
            Enabled = true;
        }

        public void DisableRagdoll()
        {
            foreach (var rb in _rigidBodies)
            {
                rb.isKinematic = true;
            }
            _animator.enabled = true;
            Enabled = false;
        }

        public void Toggle()
        {
            if (Enabled)
            {
                DisableRagdoll();
            }
            else
            {
                EanbleRagdoll();
            }
        }

        public void AddForce(Vector3 force)
        {
            foreach (var rb in _rigidBodies)
            {
                rb.AddForce(force, ForceMode.Acceleration);
            }
        }

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Ragdoll))]
    public class RagdollEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {

            if (GUILayout.Button("Toggle"))
            {
                var ragdoll = target as Ragdoll;
                ragdoll.Toggle();
            }

        }
    }
#endif
}