using UnityEngine;
using UnityEngine.UI;

public class GameClickHandler : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _pauseMenu.gameObject.SetActive(false);
        _pauseButton.onClick.AddListener(OpenPauseMenu);
        _resumeButton.onClick.AddListener(ClosePauseMenu);
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OpenPauseMenu);
        _resumeButton.onClick.RemoveListener(ClosePauseMenu);
        _exitButton.onClick.RemoveListener(Exit);
    }

    private void OpenPauseMenu()
    {
        Time.timeScale = 0;
        _pauseMenu.gameObject.SetActive(true);
    }

    private void ClosePauseMenu()
    {
        Time.timeScale = 1;
        _pauseMenu.gameObject.SetActive(false);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
