using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinCollector _player;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private CoinPool _coinPool;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private void OnEnable()
    {
        _coinCollector.CoinCollectedAction += SpawnNewCoin;
    }

    private void OnDisable()
    {
        _coinCollector.CoinCollectedAction -= SpawnNewCoin;
    }

    private void Start()
    {
        SpawnNewCoin();
    }

    private void SpawnNewCoin()
    {
        Coin coin = _coinPool.GetCoin();

        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Transform closestPointToPlayer = FindClosestSpawnPointToPlayer();

        if (closestPointToPlayer == _spawnPoints[randomIndex])
        {
            randomIndex = ++randomIndex % _spawnPoints.Count;
        }

        coin.transform.position = _spawnPoints[randomIndex].position;
    }

    private Transform FindClosestSpawnPointToPlayer()
    {
        Transform closestPointToPlayer = _spawnPoints[0];
        float minDistanceToPlayer = float.MaxValue;

        foreach (Transform spawnPoint in _spawnPoints)
        {
            float distanceToPlayer = (spawnPoint.position - _player.transform.position).magnitude;

            if (distanceToPlayer < minDistanceToPlayer)
            {
                minDistanceToPlayer = distanceToPlayer;
                closestPointToPlayer = spawnPoint;
            }
        }

        return closestPointToPlayer;
    }
}
