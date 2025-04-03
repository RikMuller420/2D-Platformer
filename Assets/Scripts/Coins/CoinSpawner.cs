using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;
    [SerializeField] private Player _player;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private Coin _activeCoin;

    private void OnEnable()
    {
        if (_activeCoin != null)
        {
            _activeCoin.OnDisabled += CoinDisabled;
        }
    }

    private void OnDisable()
    {
        if (_activeCoin != null)
        {
            _activeCoin.OnDisabled -= CoinDisabled;
        }
    }

    private void Start()
    {
        SpawnNewCoin();
    }

    private void SpawnNewCoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Transform closestPointToPlayer = FindClosestSpawnPointToPlayer();

        if (closestPointToPlayer == _spawnPoints[randomIndex])
        {
            randomIndex = ++randomIndex % _spawnPoints.Count;
        }

        _activeCoin = _coinPool.GetCoin();
        _activeCoin.transform.position = _spawnPoints[randomIndex].position;
        _activeCoin.OnDisabled += CoinDisabled;
    }

    private void CoinDisabled()
    {
        _activeCoin.OnDisabled -= CoinDisabled;
        _coinPool.ReleaseCoin(_activeCoin);
        _activeCoin = null;

        SpawnNewCoin();
    }

    private Transform FindClosestSpawnPointToPlayer()
    {
        Transform closestPointToPlayer = _spawnPoints[0];
        float minSqrDistanceToPlayer = float.MaxValue;

        foreach (Transform spawnPoint in _spawnPoints)
        {
            float sqrDistanceToPlayer = (spawnPoint.position - _player.transform.position).sqrMagnitude;

            if (sqrDistanceToPlayer < minSqrDistanceToPlayer)
            {
                minSqrDistanceToPlayer = sqrDistanceToPlayer;
                closestPointToPlayer = spawnPoint;
            }
        }

        return closestPointToPlayer;
    }
}
