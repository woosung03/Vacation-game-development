using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 

    public int totalScore = 0;     // 누적 점수 
    public int currentScore = 0;   // 이번 게임 점수
    public int highScore = 0;      // 최고 점수  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();    // 총 점수와 최고 점수 불러오기
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCurrentScore(int amount)
    {
        currentScore += amount;

        // 최고 점수 갱신
        if (currentScore > highScore)   // 최고 점수보다 현재 점수가 높을 때
        {
            highScore = currentScore;
            SaveScore(); // 하이스코어도 저장
        }
    }

    public void AddTotalScore(int amount)
    {
        totalScore += amount;
        SaveScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
