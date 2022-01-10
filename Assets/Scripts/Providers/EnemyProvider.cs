using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MeshRenderer))]
public class EnemyProvider : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible()
    {
        // TO DO Invoke event
    }
    private void OnBecameVisible()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    void OnTriggerEnter()
    {

    }

    void ReturnToPool()
    {

    }

}
