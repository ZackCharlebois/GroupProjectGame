using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject mapPositions;
    public GameObject player;

    bool isIdle;
    public bool isChasing;

    private void Start()
    {
        isIdle = true;
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            // If close enough to destination and velocity is almost zero
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    isIdle = true;
                    Debug.Log("Agent reached destination and stopped!");
                }
            }
        }

        if (isChasing)
        {
            Invoke("ChasePlayer", 1f);
            //ChasePlayer();
        }
        else if (!isChasing && isIdle)
        {
            Invoke("MoveToNextRoom", 4f);
        }
    }

    void MoveToNextRoom()
    {
        isIdle = false;
        int roomNumber = UnityEngine.Random.Range(1,mapPositions.transform.childCount);
        Vector3 roomPosition = mapPositions.transform.Find(roomNumber.ToString()).position;
        agent.SetDestination(roomPosition);
    }

    public void OnChildTriggerEnter(Collider other, GameObject child)
    {
        Debug.Log(other + " entered the enemy collider");
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = true;
            isIdle = false;
        }
    }

    public void OnChildTriggerExit(Collider other, GameObject child)
    {
        Debug.Log(other + " exited the enemy collider");
        if (other.gameObject.CompareTag("Player"))
        {
            isChasing = false;
            isIdle = true;
        }
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
