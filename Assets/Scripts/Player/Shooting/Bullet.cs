using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private bool _fire;
    [SerializeField]
    private float _speed;

    public void Fire()
    {
        _fire = true;
    }

    internal void Update()
    {
        if (_fire)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * _speed * Time.deltaTime, Time.deltaTime);
        }
    }

    internal void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Shot: {other.gameObject.name}", other.gameObject);
    }
}