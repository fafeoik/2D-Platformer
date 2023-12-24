using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirismCaster : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirismArea;
    [SerializeField] private float _duration;

    private Coroutine _castCoroutine;

    private void OnDisable()
    {
        if(_castCoroutine != null)
        {
            StopCoroutine(_castCoroutine);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_vampirismArea.gameObject.activeSelf == false)
            {
                _castCoroutine = StartCoroutine(Cast());
            }
        }
    }

    private IEnumerator Cast()
    {
        var waitForDuration = new WaitForSeconds(_duration);

        _vampirismArea.gameObject.SetActive(true);

        yield return waitForDuration;

        _vampirismArea.gameObject.SetActive(false);
    }
}
