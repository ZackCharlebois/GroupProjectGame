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

    private enum State { Idle, MovingToRoom, Chasing }
    private State state = State.Idle;

    float idleTimer = 0f;
    float idleDelay = 2f;

    private void Start()
    {
        state = State.Idle;
    }


    void Update()
    {
        switch (state)
        {
            case State.Idle:
                HandleIdle();
                break;

            case State.MovingToRoom:
                HandleMovingToRoom();
                break;

            case State.Chasing:
                HandleChasing();
                break;
        }
    }

    void HandleIdle()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDelay)
        {
            idleTimer = 0f;
            MoveToNextRoom();
            state = State.MovingToRoom;
        }
    }

    void HandleMovingToRoom()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && agent.velocity.sqrMagnitude < 0.05f)
        {
            state = State.Idle;
        }
    }

    void HandleChasing()
    {
        agent.SetDestination(player.transform.position);
    }

    void MoveToNextRoom()
    {
        int roomNumber = UnityEngine.Random.Range(1,mapPositions.transform.childCount);
        Vector3 roomPosition = mapPositions.transform.Find(roomNumber.ToString()).position;
        agent.SetDestination(roomPosition);
    }

    public void OnChildTriggerEnter(Collider other, GameObject child)
    {
        Debug.Log(other + " entered the enemy collider");
        if (other.gameObject.CompareTag("Player"))
        {
            state = State.Chasing;
        }
    }

    public void OnChildTriggerExit(Collider other, GameObject child)
    {
        Debug.Log(other + " exited the enemy collider");
        if (other.gameObject.CompareTag("Player"))
        {
            state = State.Idle;
            idleTimer = 0f;
        }
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
