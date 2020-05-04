using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target = null;
    [SerializeField] float damage = 40f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.TakeDamage(damage);
        Debug.Log("bang bang");
    }

    public void OnDamageTaken()
    {
        Debug.Log("I am working");
    }
}