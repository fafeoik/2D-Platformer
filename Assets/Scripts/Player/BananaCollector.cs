using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BananaCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _bananaEaten;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Banana>(out Banana banana))
        {
            _bananaEaten?.Invoke(banana.HealAmount);
            Destroy(banana.gameObject);
        }
    }
}
