using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private float _smoothBarSpeed;
    [SerializeField] private Health _health;

    private Coroutine _smoothHealthChangeCoroutine;

    private void OnEnable()
    {
        _health.HealthChanged += OnShowHealth;
    }

    private void OnDisable()
    {
        if (_smoothHealthChangeCoroutine != null)
        {
            StopCoroutine(_smoothHealthChangeCoroutine);
        }
    }

    public void OnShowHealth(int currentHealth)
    {
       
        ShowSmoothHealthBar(currentHealth);
    }

    private void ShowSmoothHealthBar(int currentHealth)
    {
        _smoothHealthChangeCoroutine = StartCoroutine(ChangeHealthSmoothly(currentHealth));
    }

    private IEnumerator ChangeHealthSmoothly(int currentHealth)
    {
        bool isWorking = true;

        while (isWorking)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, currentHealth, _smoothBarSpeed);

            if (_smoothHealthBar.value == currentHealth)
            {
                isWorking = false;
            }

            yield return null;
        }
    }
}
