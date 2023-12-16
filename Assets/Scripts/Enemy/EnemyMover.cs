using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private float _speed;

    private int _currentPointIndex;
    private Transform[] _movePoints;
    private Coroutine _patrolCoroutine;
    private Coroutine _followPlayerCoroutine;

    private void Start()
    {
        _movePoints = new Transform[_pointsContainer.childCount];

        for (int i = 0; i < _pointsContainer.childCount; i++)
            _movePoints[i] = _pointsContainer.GetChild(i);

        _patrolCoroutine = StartCoroutine(Patrol());
    }

    private void OnDestroy()
    {
        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
        }

        if (_followPlayerCoroutine != null)
        {
            StopCoroutine(_followPlayerCoroutine);
        }
    }

    public void StartFollowPlayer(Player player)
    {
        StopCoroutine(_patrolCoroutine);
        _followPlayerCoroutine = StartCoroutine(FollowPlayer(player));
    }

    public void StopFollowPlayer()
    {
        StopCoroutine(_followPlayerCoroutine);
        _patrolCoroutine = StartCoroutine(Patrol());
    }

    private IEnumerator FollowPlayer(Player player)
    {
        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator Patrol()
    {
        while (enabled)
        {
            Transform currentPoint = _movePoints[_currentPointIndex];

            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

            if (transform.position == currentPoint.position)
            {
                ChooseNextPoint();
            }

            yield return null;
        }
    }

    private void ChooseNextPoint()
    {
        _currentPointIndex = ++_currentPointIndex % _movePoints.Length;
    }
}
