using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
