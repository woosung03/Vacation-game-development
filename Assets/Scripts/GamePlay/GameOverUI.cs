using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public Text scoreText;
    public Text coinText;
    public GameObject gameOverPanel; // UI �г� (�ʱ⿣ ��Ȱ��)

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
        Time.timeScale = 0f;  // ���� ����
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameReady");
    }
}
