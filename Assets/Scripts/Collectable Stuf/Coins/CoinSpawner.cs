using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private ObjectPool<Coin> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;
    private int _lastSpawnIndex = int.MaxValue;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => InstantiateCoin(),
            actionOnGet: (coin) => coin.Activate(),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);

        if (randomIndex == _lastSpawnIndex)
        {
            randomIndex = ++randomIndex % _spawnPoints.Count;
        }

        Coin coin = _pool.Get();
        coin.transform.position = _spawnPoints[randomIndex].position;
        coin.Deactivated += CoinDisabled;
        _lastSpawnIndex = randomIndex;
    }

    private void CoinDisabled(Coin coin)
    {
        coin.Deactivated -= CoinDisabled;
        _pool.Release(coin);

        SpawnCoin();
    }

    private Coin InstantiateCoin()
    {
        Coin coin = Instantiate(_coinPrefab);
        coin.gameObject.SetActive(false);

        return coin;
    }
}
