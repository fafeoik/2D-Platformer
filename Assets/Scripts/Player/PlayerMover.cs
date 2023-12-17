using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private UnityEvent _playerRan;
    [SerializeField] private UnityEvent _playerStopped;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton(Horizontal))
        {
            Move();
        }
        else
        {
            _playerStopped?.Invoke();
        }
    }

    private void Move()
    {
        _playerRan?.Invoke();
        Vector3 direction = transform.right * Input.GetAxis(Horizontal);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        _spriteRenderer.flipX = direction.x < 0.0f;
    }
}