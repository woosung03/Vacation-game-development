using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreText;      //  (���� ǥ�ÿ�)
    public TMP_Text coinText;       //  (���� ǥ�ÿ�)
    public GameObject gameOverPanel; // UI �г� (�ʱ⿣ ��Ȱ��)
    public GameObject HPSlider; // HP �����̴� UI (���� ���� �� ����)

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int score, int coins)
    {
        scoreText.text = "Score: " + score; // ���� ���� ǥ��
        coinText.text = "Coins: " + coins;  // ���� ���� ǥ��

        gameOverPanel.SetActive(true);  // ���� ���� �г� Ȱ��ȭ
        HPSlider.SetActive(false); // ���� ���� �� HP �����̴� ��Ȱ��ȭ

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
