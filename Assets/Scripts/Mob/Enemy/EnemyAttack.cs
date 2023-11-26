using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _damage;
    public void Attack(GameObject target)
    {
        Debug.Log("Оно пытается драться");
    }
    
}
