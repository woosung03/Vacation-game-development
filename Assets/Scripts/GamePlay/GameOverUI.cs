using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public GameObject gameOverPanel; // UI 패널 (초기엔 비활성)

    private int finalScore;
    private int finalCoins;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int score, int coins)
    {
        finalScore = score;
        finalCoins = coins;

        scoreText.text = "Score: " + finalScore;
        coinText.text = "Coins: " + finalCoins;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;  // 게임 정지
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameReady");
    }
}
