using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinCollector : MonoBehaviour
{
    private int _coinCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            GetCoin(coin);
        }
    }

    private void GetCoin(Coin coin)
    {
        _coinCount++;
        coin.Deactivate();
    }
}
