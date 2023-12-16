using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFollowTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<Player> _playerFound;
    [SerializeField] private UnityEvent _playerRanAway;

    private bool _isFollowingPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerFound?.Invoke(player);
            _isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isFollowingPlayer)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                _playerRanAway?.Invoke();
                _isFollowingPlayer = false;
            }
        }
    }
}