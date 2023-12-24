using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _purposeAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health enemyHealth) && _purposeAttack == (_purposeAttack | (1 << enemyHealth.gameObject.layer)))
        {
            DealDamage(enemyHealth);
        }
    }

    private void DealDamage(Health enemyHealth)
    {
        enemyHealth.TakeDamage(_damage);
    }
}
