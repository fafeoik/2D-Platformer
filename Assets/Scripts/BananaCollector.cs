using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCollector : MonoBehaviour
{
    private int _bananaAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Banana>(out Banana banana))
        {
            _bananaAmount++;
            Destroy(banana.gameObject);

            print($"����� ������. UI � TextMeshPro ��� �� ���������, ������� ���: ������� �������: {_bananaAmount}");
        }
    }
}
