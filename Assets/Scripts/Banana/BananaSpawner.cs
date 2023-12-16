using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    [SerializeField] private Transform _bananaPrefab;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            Instantiate(_bananaPrefab, transform.GetChild(i).position, Quaternion.identity);
    }
}
