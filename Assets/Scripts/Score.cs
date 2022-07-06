using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public int _score = 0;

    private void Update()
    {
        _scoreText.text = _score.ToString("000000");
    }

    public void AddPoints(int _points)
    {
        _score += _points;
    }

    public void SubtractPoints(int _points)
    {
        _score -= _points;
    }
}
