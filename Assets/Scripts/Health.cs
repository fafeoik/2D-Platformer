using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    public void Heal(float healAmount)
    {
        _health += healAmount;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }

        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
