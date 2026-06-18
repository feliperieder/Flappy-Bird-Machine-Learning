using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _currentScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _currentScore = 0;
        _currentScoreText.text = _currentScore.ToString();


        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            _highScoreText.text = "0";
        }
    }


    private void UpdateHighScore()
    {
        if (_currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            _highScoreText.text = _currentScore.ToString();
        }
    }

    public void UpdateScore()
    {
        _currentScore ++;
        _currentScoreText.text = _currentScore.ToString();
        UpdateHighScore();
    }
}
