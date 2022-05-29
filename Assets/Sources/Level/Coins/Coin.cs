using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public event Action NeedChangeScore;
    public event Action<Coin> NeedUnsubscribe;

    public void GetUp()
    {
        NeedChangeScore?.Invoke();
        NeedUnsubscribe?.Invoke(this);
        Destroy(gameObject);
    }
}
