using UnityEngine;
using UnityEngine.Events;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    public event UnityAction<Coin> NeedSubscription;

    public void Generate(Transform[] spawnPoints)
    {
        Coin tempCoin;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            tempCoin = Instantiate(_prefab, spawnPoints[i]);
            NeedSubscription?.Invoke(tempCoin);
        }
    }
}
