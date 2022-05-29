using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private Sprite _startSprite;
    [SerializeField] private Sprite _touchSprite;

    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _startSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _spriteRenderer.sprite = _touchSprite;
    }
}
