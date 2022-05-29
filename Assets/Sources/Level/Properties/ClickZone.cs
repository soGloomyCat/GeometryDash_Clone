using UnityEngine;
using UnityEngine.Events;

public class ClickZone : MonoBehaviour
{
    public event UnityAction IsClicked;

    private void OnMouseDown() => IsClicked?.Invoke();
}
