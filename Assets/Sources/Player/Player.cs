using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<Collision2D, Player> CollidedWithObject;
    public event UnityAction<Collider2D, Player> EnteredTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollidedWithObject?.Invoke(collision, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnteredTrigger?.Invoke(collision, this);
    }
}
