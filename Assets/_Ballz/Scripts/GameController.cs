using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameStorage _storage;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _bestScore;
  
    private void Awake()
    {
        _storage.Score = 0;
        _bestScore.text = _storage.BestScore.ToString();
    }

    public void AddOneToScore()
    {
        _storage.Score++;
        
        _score.text = _storage.Score.ToString();
    }

    private void OnDestroy()
    {
        if (_storage.BestScore < _storage.Score)
        {
            _storage.BestScore = _storage.Score;
        }
    }
}