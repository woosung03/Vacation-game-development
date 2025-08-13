using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;      //  (점수 표시용)
    public TMP_Text coinText;       //  (코인 표시용)
    public GameObject gameOverPanel; // UI 패널 (초기엔 비활성)

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int score, int coins)
    {
        if (scoreText == null) Debug.LogError("scoreText가 할당되지 않았습니다.");
        if (coinText == null) Debug.LogError("coinText가 할당되지 않았습니다.");
        if (gameOverPanel == null) Debug.LogError("gameOverPanel이 할당되지 않았습니다.");


        scoreText.text = "Score: " + score; // 현재 점수 표시
        coinText.text = "Coins: " + coins;  // 현재 코인 표시

        gameOverPanel.SetActive(true);  // 게임 오버 패널 활성화
        Time.timeScale = 0f;            // 게임 일시 정지

        ScoreManager.Instance.SaveData();
    }

    public void OnBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameReady");
    }

    public void ShowGameOver()  //함수오버로드
    {
        int score = ScoreManager.Instance.CurrentScore;
        int coins = FindObjectOfType<GameSessionUI>()?.GetCoins() ?? 0;
        ShowGameOver(score, coins);
    }
}
