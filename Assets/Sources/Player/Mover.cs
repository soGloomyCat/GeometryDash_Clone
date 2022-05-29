using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Mover : MonoBehaviour
{
    private const float _horizontalShift = 1;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotateAngle;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private bool _isOnGround;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isOnGround = true;
    }

    public void InizializeJump()
    {
        if (_isOnGround)
            Jump();
    }

    private void Update() => SimulateMove();

    private void SimulateMove()
    {
        Vector2 tempDirection;

        tempDirection = new Vector2(transform.position.x + _horizontalShift, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, tempDirection, _speed * Time.deltaTime);
        transform.Rotate(Vector3.back * _rotateAngle * Time.deltaTime, Space.World);
    }

    private void Jump()
    {
        _isOnGround = false;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) => _isOnGround = true;
}
