using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    private void OnEnable()
    {
        _score = 0;
        UpdateScoreText();
    }

    public void ChangeScore()
    {
        _score++;
        UpdateScoreText();
    }

    private void UpdateScoreText() => _scoreText.text = $"Собрано - {_score}";
}
