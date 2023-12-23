using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _verticalPositionIncreaser;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_player.position.x, _player.position.y + _verticalPositionIncreaser, transform.position.z), _speed * Time.deltaTime);
    }
}
