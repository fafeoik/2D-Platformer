using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _valuePerSecond;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private LayerMask _purposeAttack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health enemyHealth) && _purposeAttack == (_purposeAttack | (1 << enemyHealth.gameObject.layer)))
        {
            enemyHealth.TakeDamage(_valuePerSecond * Time.fixedDeltaTime);
            _playerHealth.Heal(_valuePerSecond * Time.fixedDeltaTime);
        }
    }
}