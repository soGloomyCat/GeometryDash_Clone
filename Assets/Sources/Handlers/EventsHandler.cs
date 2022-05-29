using UnityEngine;

public class EventsHandler : MonoBehaviour
{
    [SerializeField] private PlatformsGenerator _platformsGenerator;
    [SerializeField] private CoinsGenerator _coinsGenerator;
    [SerializeField] private Stalker _stalker;
    [SerializeField] private DestroyHandler _destroyer;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private SceneHandler _sceneHandler;
    [SerializeField] private Player _player;
    [SerializeField] private Collector _collecctor;
    [SerializeField] private Mover _mover;
    [SerializeField] private ClickZone _clickZone;

    private void OnEnable()
    {
        _platformsGenerator.PlatformSpawned += _coinsGenerator.Generate;
        _coinsGenerator.NeedSubscription += Subscribe;
        _collisionHandler.StartStalking += _stalker.InizializeTarget;
        _collisionHandler.RequiredDestroy += _destroyer.DestroyTarget;
        _collisionHandler.RequiredRestartScene += _sceneHandler.ReloadScene;
        _player.CollidedWithObject += _collisionHandler.HandleCollision;
        _player.EnteredTrigger += _collisionHandler.HandleTrigger;
        _clickZone.IsClicked += _mover.InizializeJump;
    }

    private void OnDisable()
    {
        _platformsGenerator.PlatformSpawned -= _coinsGenerator.Generate;
        _coinsGenerator.NeedSubscription += Subscribe;
        _collisionHandler.StartStalking -= _stalker.InizializeTarget;
        _collisionHandler.RequiredDestroy -= _destroyer.DestroyTarget;
        _collisionHandler.RequiredRestartScene -= _sceneHandler.ReloadScene;
        _player.CollidedWithObject -= _collisionHandler.HandleCollision;
        _player.EnteredTrigger -= _collisionHandler.HandleTrigger;
        _clickZone.IsClicked -= _mover.InizializeJump;
    }

    private void Subscribe(Coin coin)
    {
        coin.NeedChangeScore += _collecctor.ChangeScore;
        coin.NeedUnsubscribe += Unsubscribe;
    }

    private void Unsubscribe(Coin coin)
    {
        coin.NeedChangeScore -= _collecctor.ChangeScore;
        coin.NeedUnsubscribe -= Unsubscribe;
    }
}
