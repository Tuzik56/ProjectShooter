using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> points;

    private int currentPoint;

    void Start()
    {
        
    }

    public void Patrol()
    {
        if (agent.transform.position == agent.pathEndPosition)
        {
            UpdatePoint();
        }
        agent.SetDestination(points[currentPoint].position);
    }

    private void UpdatePoint()
    {
        currentPoint = Random.Range(0, points.Count);
    }
}
