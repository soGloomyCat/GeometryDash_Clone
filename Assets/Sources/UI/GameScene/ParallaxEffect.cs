using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _background;
    private float _backgroundHorizontalPosition;
    private Vector2 _backgroundSize;

    private void OnEnable()
    {
        _background = GetComponent<RawImage>();
        _backgroundSize = new Vector2(_background.uvRect.width, _background.uvRect.height);
    }

    private void Update()
    {
        _backgroundHorizontalPosition += _speed * Time.deltaTime;
        _background.uvRect = new Rect(new Vector2(_backgroundHorizontalPosition, _background.uvRect.y), _backgroundSize);
    }
}
