using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            DealDamage(player);
        }
    }

    public void DealDamage(Player player)
    {
        player.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
