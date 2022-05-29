using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AuthorPanelAnimationHandler : MonoBehaviour
{
    private const string _closeAnimationLabel = "Disappearance";

    private Animator _animator;

    public event Action<float> Played;

    public void PlayClosingAnimation()
    {
        _animator.Play(_closeAnimationLabel);
        Played?.Invoke(_animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void OnEnable() => _animator = GetComponent<Animator>();
}
