using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private Coin _activeCoin;
    private int _lastSpawnIndex = int.MaxValue;

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

        if (randomIndex == _lastSpawnIndex)
        {
            randomIndex = ++randomIndex % _spawnPoints.Count;
        }

        _activeCoin = _coinPool.GetCoin();
        _activeCoin.transform.position = _spawnPoints[randomIndex].position;
        _activeCoin.OnDisabled += CoinDisabled;
        _lastSpawnIndex = randomIndex;
    }

    private void CoinDisabled()
    {
        _activeCoin.OnDisabled -= CoinDisabled;
        _coinPool.ReleaseCoin(_activeCoin);
        _activeCoin = null;

        SpawnNewCoin();
    }
}
