using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float _speed = 0.5f;
    public float _damage = 25.0f;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, player.transform.position, _speed * Time.deltaTime);
    }


}
