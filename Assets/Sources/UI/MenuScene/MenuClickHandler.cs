using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuClickHandler : MonoBehaviour
{
    private const int _gameSceneIndex = 1;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _authorOpenButton;
    [SerializeField] private Button _authorCloseButton;
    [SerializeField] private AuthorPanel _authorPanel;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(LoadGameScene);
        _exitButton.onClick.AddListener(ExitGame);
        _authorOpenButton.onClick.AddListener(OpenAuthorPanel);
        _authorCloseButton.onClick.AddListener(CloseAuthorPanel);
        _authorPanel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(LoadGameScene);
        _exitButton.onClick.RemoveListener(ExitGame);
        _authorOpenButton.onClick.RemoveListener(OpenAuthorPanel);
        _authorCloseButton.onClick.RemoveListener(CloseAuthorPanel);
    }

    private void LoadGameScene() => SceneManager.LoadScene(_gameSceneIndex);

    private void ExitGame() => Application.Quit();

    private void OpenAuthorPanel() => _authorPanel.Activate();

    private void CloseAuthorPanel() => _authorPanel.Deactivate();
}
