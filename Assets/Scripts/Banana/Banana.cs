using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    [SerializeField] private int _healAmount;

    public int HealAmount => _healAmount;
}
