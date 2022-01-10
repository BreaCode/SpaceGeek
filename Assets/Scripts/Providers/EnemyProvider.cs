using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MeshRenderer))]
public class EnemyProvider : MonoBehaviour
{
    void OnBecameInvisible()
    {   
        // TO DO Invoke event
    }

    void OnTriggerEnter()
    {

    }

    void ReturnToPool()
    {

    }

}
