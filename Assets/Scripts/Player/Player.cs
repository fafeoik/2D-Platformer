using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private PlayerAttackTrigger _attackTrigger;

    private int _health;

    private void Start() 
    {
        _health = _maxHealth;
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;

        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        print($"Игрок съел банан и подхилился. хп: {_health}");
    }

    public void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        print($"Игрок получил урон. Осталось хп: {_health}.");

        CheckIfDead();
    }

    public void CheckIfDead()
    {
        if(_health <= 0)
        {
            print("Игрок умер.");
            Destroy(gameObject);
        }
    }
}
