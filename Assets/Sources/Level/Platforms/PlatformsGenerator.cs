using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsGenerator : MonoBehaviour
{
    private const float _platformScale = 21;
    private const float _tripOffset = -1;

    [SerializeField] private Camera _camera;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private Transform _pool;

    private Platform _tempPlatform;
    private Platform _lastPlatform;
    private List<Platform> _platformsList;

    public event UnityAction<Transform[]> PlatformSpawned;

    private void OnEnable()
    {
        _platformsList = new List<Platform>();
        Generate();
    }

    private void Update()
    {
        if (CheckAvalaibelInactivePlatforms())
            InstallNextPlatform();

        DeactivatePlatform();
    }

    private void Generate()
    {
        Platform tempPlatform;

        for (int i = 0; i < _platforms.Length; i++)
        {
            tempPlatform = Instantiate(_platforms[i], _pool);
            _platformsList.Add(tempPlatform);
            tempPlatform.gameObject.SetActive(false);
        }

        _tempPlatform = _platformsList[0];
    }

    private bool CheckAvalaibelInactivePlatforms()
    {
        List<Platform> inactivePlatforms;

        inactivePlatforms = new List<Platform>();

        if (_camera.transform.position.x >= _tempPlatform.transform.position.x)
        {
            foreach (var platform in _platformsList)
            {
                if (platform.gameObject.activeSelf == false)
                {
                    inactivePlatforms.Add(platform);
                }
            }

            _tempPlatform = inactivePlatforms[Random.Range(0, inactivePlatforms.Count)];
            return true;
        }

        return false;
    }

    private void InstallNextPlatform()
    {
        if (_lastPlatform != null)
            _tempPlatform.transform.position = new Vector3(_lastPlatform.transform.position.x + _platformScale, _lastPlatform.transform.position.y, _lastPlatform.transform.position.z);
        else
            _tempPlatform.transform.position = new Vector3(_pool.transform.position.x, _pool.transform.position.y, _pool.transform.position.z);

        _tempPlatform.gameObject.SetActive(true);
        _lastPlatform = _tempPlatform;
        PlatformSpawned?.Invoke(_tempPlatform.GetSpawnPoints());
    }

    private void DeactivatePlatform()
    {
        foreach (var platform in _platformsList)
        {
            if (platform.gameObject.activeSelf == true)
            {
                Vector3 position = _camera.WorldToViewportPoint(platform.transform.position);

                if (position.x < _tripOffset)
                    platform.gameObject.SetActive(false);
            }
        }
    }
}
