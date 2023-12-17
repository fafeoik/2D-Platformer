using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly int Run = Animator.StringToHash(nameof(Run));
    private readonly int Idle = Animator.StringToHash(nameof(Idle));

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartRunAnimation()
    {
        _animator.SetTrigger(Run);
    }

    public void StartIdleAnimation()
    {
        _animator.SetTrigger(Idle);
    }
}
