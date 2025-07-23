using TMPro;
using UnityEngine;

public class GameSessionUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinText;  

    private int sessionScore = 0;   // 게임 세션 동안의 점수
    private int sessionCoins = 0;   // 게임 세션 동안의 코인 수

    void Start()
    {
        ResetSession();   // 게임 시작 시 초기화
    }

    public void AddScore(int amount)    // 점수 추가
    {
        sessionScore += amount;
        UpdateUI();
    }

    public void AddCoin(int amount)     // 코인 추가
    {
        sessionCoins += amount;
        UpdateUI();
    }

    private void UpdateUI()             // UI 업데이트
    {
        scoreText.text = "Score: " + sessionScore;
        coinText.text = "Coins: " + sessionCoins;
    }

    public void ResetSession()          // 게임 세션 초기화
    {
        sessionScore = 0;
        sessionCoins = 0;
        UpdateUI();
    }

    // 최고 점수 저장 & 불러오기
    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (sessionScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", sessionScore);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()   // 최고 점수 불러오기
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
