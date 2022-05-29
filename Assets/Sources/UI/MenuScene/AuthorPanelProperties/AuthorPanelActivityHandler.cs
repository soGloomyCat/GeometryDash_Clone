using System.Collections;
using UnityEngine;

public class AuthorPanelActivityHandler : MonoBehaviour
{
    private Coroutine _coroutine;
    private float _playbackTime;
    private float _currentTime;

    public void Activate()
    {
        gameObject.SetActive(true);
        _playbackTime = 0;
        _currentTime = 0;
    }

    public void Deactivate(float playbackTime)
    {
        _playbackTime = playbackTime;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MonitorReadyDeactivate());
    }

    private IEnumerator MonitorReadyDeactivate()
    {
        while (_currentTime <= _playbackTime)
        {
            _currentTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
