using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameStorage _storage;
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _score;
    
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnRateClicked()
    {
        Application.OpenURL("https://t.me/iamideo");
    }

    public void OnSoundClicked()
    {
        
    }

    public void OnStatsClicked()
    {
        
    }

    private void Awake()
    {
        _score.text = _storage.Score.ToString();
        _bestScore.text = "BEST " + _storage.BestScore;
    }
}
