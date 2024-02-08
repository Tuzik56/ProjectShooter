using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitScript : MonoBehaviour
{
    private PlayerHp playerHp;
    [SerializeField] private float heal = 50;

    void Start()
    {
        playerHp = GetComponentInParent<PlayerHp>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Heal();
        }
    }

    private void Heal()
    {
        playerHp.ChangeHp(heal);
        Destroy(gameObject);
    }
}
