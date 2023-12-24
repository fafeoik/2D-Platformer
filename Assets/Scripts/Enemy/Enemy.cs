using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _purposeAttack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health playerHealth) && _purposeAttack == (_purposeAttack | (1 << playerHealth.gameObject.layer)))
        {
            DealDamage(playerHealth);
        }
    }

    public void DealDamage(Health playerHealth)
    {
        playerHealth.TakeDamage(_damage);
    }
}
