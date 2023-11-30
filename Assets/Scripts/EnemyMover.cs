using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _pointsContainer;
    [SerializeField] private float _speed;

    private int _currentPointIndex;
    private Coroutine _moveCoroutine;
    private Transform[] _movePoints;

    private void Start()
    {
        _movePoints = new Transform[_pointsContainer.childCount];

        for (int i = 0; i < _pointsContainer.childCount; i++)
            _movePoints[i] = _pointsContainer.GetChild(i);

        _moveCoroutine = StartCoroutine(Move());
    }

    private void OnDestroy()
    {
        StopCoroutine(_moveCoroutine);
    }

    private IEnumerator Move()
    {
        while (enabled)
        {
            Transform currentPoint = _movePoints[_currentPointIndex];

            bool isWorking = true;

            while (isWorking)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

                if (transform.position == currentPoint.position)
                {
                    isWorking = false;

                    ChooseNextPoint();
                }

                yield return null;
            }
        }
    }

    private void ChooseNextPoint()
    {
        _currentPointIndex = ++_currentPointIndex % _movePoints.Length;
    }
}
