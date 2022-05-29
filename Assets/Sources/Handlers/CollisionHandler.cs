using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public event UnityAction<Transform> StartStalking;
    public event UnityAction<UnityEngine.Object> RequiredDestroy;
    public event UnityAction RequiredRestartScene;

    public void HandleTrigger(Collider2D collision, Player player)
    {
        if (collision.TryGetComponent(out StartZone startpoint))
            StartStalking?.Invoke(player.transform);

        if (collision.transform.TryGetComponent(out Coin coin))
            coin.GetUp();

        if (collision.TryGetComponent(out DeadZone deadZone))
        {
            RequiredDestroy?.Invoke(player.gameObject);
            RequiredRestartScene.Invoke();
        }
    }

    public void HandleCollision(Collision2D collision, Player player)
    {
        if (collision.transform.position.y >= player.transform.position.y)
        {
            RequiredDestroy?.Invoke(player.gameObject);
            RequiredRestartScene.Invoke();
        }
    }
}
