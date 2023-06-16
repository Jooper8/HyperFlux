using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score, bestScore;
    [SerializeField] TMP_Text scoreText, highScoreText;
    private static GameManager instance;
    [SerializeField] GameObject gameOver;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("GameManager");
                instance = singletonObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        highScoreText.text = bestScore.ToString();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            highScoreText.text = bestScore.ToString();
        }
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void GameOver()
    {
        Debug.Log(bestScore);
        if (bestScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        gameOver.SetActive(true);
    }
    public void RestartLevel()
    {
        score = 0;
        UpdateScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
