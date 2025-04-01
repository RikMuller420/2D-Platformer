using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _poolMaxSize = 10;

    private ObjectPool<Coin> _pool;

    private void OnValidate()
    {
        if (_poolMaxSize < _poolCapacity)
        {
            _poolMaxSize = _poolCapacity;
        }
    }

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

    private Coin InstantiateCoin()
    {
        Coin coin = Instantiate(_coinPrefab);
        coin.gameObject.SetActive(false);
        coin.SetReleaseInPoolDelegate(() => _pool.Release(coin));

        return coin;
    }

    private void SpawnNewCoin(Coin coin)
    {
        coin.Activate();
    }
}
