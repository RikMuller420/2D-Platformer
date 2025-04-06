using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private ObjectPool<Coin> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => InstantiateCoin(),
            actionOnGet: (coin) => SpawnNewCoin(coin),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    public Coin GetCoin()
    {
        return _pool.Get();
    }

    public void ReleaseCoin(Coin coin)
    {
        _pool.Release(coin);
    }

    private Coin InstantiateCoin()
    {
        Coin coin = Instantiate(_coinPrefab);
        coin.gameObject.SetActive(false);

        return coin;
    }

    private void SpawnNewCoin(Coin coin)
    {
        coin.Activate();
    }
}
