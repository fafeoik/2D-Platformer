using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly int Run = Animator.StringToHash(nameof(Run));
    private readonly int Idle = Animator.StringToHash(nameof(Idle));

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }
        else
        {
            _animator.SetTrigger(Idle);
        }
    }

    private void Move()
    {
        _animator.SetTrigger(Run);
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        _spriteRenderer.flipX = direction.x < 0.0f;
    }
}
