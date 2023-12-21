using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly int Click = Animator.StringToHash(nameof(Click));

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayClickAnimation()
    {
        _animator.SetTrigger(Click);
    }
}
