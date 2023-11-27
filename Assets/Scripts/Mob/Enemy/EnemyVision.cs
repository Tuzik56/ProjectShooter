using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float rayDistance;
    [SerializeField] private int rayCount;
    [SerializeField] private float rayAngle;



    public bool DetectPlayer()
    {
        bool result = false;
        float j = 0;
        for (int i = 0; i < rayCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);
    
            j += rayAngle * Mathf.Deg2Rad / rayCount;
    
            Vector3 direction = agent.transform.TransformDirection(new Vector3(x, 0, y));
            result = result || MakeRay(direction);
    
            if (x != 0)
            {
                direction = agent.transform.TransformDirection(new Vector3(-x, 0, y));
                result = result || MakeRay(direction);
            }
        }
        return result;
    }

    private bool MakeRay(Vector3 direction)
    {
        Vector3 position = agent.transform.position + new Vector3(0, 1, 0);
        var ray = new Ray(position, direction);

        Debug.DrawRay(position, direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            return (hit.collider.tag == "Player");
            
        }
        return false;
    }

    public bool DecectObstacle()
    {
        Vector3 position = agent.transform.position + new Vector3(0, 1, 0);
        Vector3 direction = agent.transform.forward;
        var ray = new Ray(position, direction);

        Debug.DrawRay(position, direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            return (hit.collider.tag == "Player");

        }
        return false;
    }

    public bool CheckDistance(GameObject target, float distance)
    {
        return Vector3.Distance(agent.transform.position, target.transform.position) < distance;
    }
}
