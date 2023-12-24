using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> points;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private AudioClip _audioClip;

    private int currentPoint;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Patrol()
    {
        if (agent.transform.position == agent.pathEndPosition)
        {
            ShowReachPointEffect();
            UpdatePoint();
        }
        agent.SetDestination(points[currentPoint].position);
    }

    public void Stay()
    {
        agent.SetDestination(agent.transform.position);
    }

    public void LookOnTarget(GameObject target)
    {
        Vector3 lookPos = target.transform.position - agent.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, rotationSpeed);
    
    }

    public void ChaseTarget(GameObject target)
    {
        agent.SetDestination(target.transform.position);
    }

    private void UpdatePoint()
    {
        currentPoint = Random.Range(0, points.Count);
    }

    private void ShowReachPointEffect()
    {
        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
