using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<Enemy> _playerAttacked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _playerAttacked?.Invoke(enemy);
        }
    }
}
