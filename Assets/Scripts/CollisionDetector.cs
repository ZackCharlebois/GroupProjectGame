using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private EnemyController parent;

    void Start()
    {
        parent = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (parent != null)
        {
            parent.OnChildTriggerEnter(other, gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (parent != null)
        {
            parent.OnChildTriggerExit(other, gameObject);
        }
    }
}
