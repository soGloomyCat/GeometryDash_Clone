using UnityEngine;

public class Platform : MonoBehaviour
{
    private const int _coinIndex = 0;

    [SerializeField] private Transform _spawnCoinsPool;

    public Transform SpawnCoinsPool => _spawnCoinsPool;

    public Transform[] GetSpawnPoints()
    {
        Transform[] tempPoints;

        tempPoints = new Transform[_spawnCoinsPool.childCount];

        for (int i = 0; i < tempPoints.Length; i++)
            tempPoints[i] = _spawnCoinsPool.GetChild(i);

        return tempPoints;
    }

    private void OnDisable() => Clear();

    private void Clear()
    {
        Transform[] tempPoints;

        tempPoints = GetSpawnPoints();

        foreach (var point in tempPoints)
            if (point.childCount > 0)
                Destroy(point.GetChild(_coinIndex).gameObject);
    }
}
