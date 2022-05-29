using UnityEngine;

public class Stalker : MonoBehaviour
{
    private Transform _target;
    private float _offset;

    public void InizializeTarget(Transform target)
    {
        _target = target;
        _offset = -target.transform.position.x;
    }

    private void Update()
    {
        if (_target != null)
            transform.position = new Vector3(_target.transform.position.x + _offset, transform.position.y, transform.position.z);
    }
}
