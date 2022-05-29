using UnityEngine;

public class AuthorPanel : MonoBehaviour
{
    [SerializeField] private AuthorPanelAnimationHandler _animationHandler;
    [SerializeField] private AuthorPanelActivityHandler _activityHandler;

    public void Activate() => _activityHandler.Activate();

    public void Deactivate() => _animationHandler.PlayClosingAnimation();

    private void OnEnable() => _animationHandler.Played += _activityHandler.Deactivate;
}