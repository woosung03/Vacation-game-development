using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;      //  (���� ǥ�ÿ�)
    public TMP_Text coinText;       //  (���� ǥ�ÿ�)
    public GameObject gameOverPanel; // UI �г� (�ʱ⿣ ��Ȱ��)

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int score, int coins)
    {
        if (scoreText == null) Debug.LogError("scoreText�� �Ҵ���� �ʾҽ��ϴ�.");
        if (coinText == null) Debug.LogError("coinText�� �Ҵ���� �ʾҽ��ϴ�.");
        if (gameOverPanel == null) Debug.LogError("gameOverPanel�� �Ҵ���� �ʾҽ��ϴ�.");


        scoreText.text = "Score: " + score; // ���� ���� ǥ��
        coinText.text = "Coins: " + coins;  // ���� ���� ǥ��

        gameOverPanel.SetActive(true);  // ���� ���� �г� Ȱ��ȭ
        Time.timeScale = 0f;            // ���� �Ͻ� ����

        ScoreManager.Instance.SaveData();
    }

    public void OnBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameReady");
    }

    public void ShowGameOver()  //�Լ������ε�
    {
        int score = ScoreManager.Instance.CurrentScore;
        int coins = FindObjectOfType<GameSessionUI>()?.GetCoins() ?? 0;
        ShowGameOver(score, coins);
    }
}
