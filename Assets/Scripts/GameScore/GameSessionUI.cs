using TMPro;
using UnityEngine;

public class GameSessionUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinText;  

    private int sessionScore = 0;   // ���� ���� ������ ����
    private int sessionCoins = 0;   // ���� ���� ������ ���� ��

    void Start()
    {
        ResetSession();   // ���� ���� �� �ʱ�ȭ
    }

    public void AddScore(int amount)    // ���� �߰�
    {
        sessionScore += amount;
        UpdateUI();
    }

    public void AddCoin(int amount)     // ���� �߰�
    {
        sessionCoins += amount;
        UpdateUI();
    }

    private void UpdateUI()             // UI ������Ʈ
    {
        scoreText.text = "Score: " + sessionScore;
        coinText.text = "Coins: " + sessionCoins;
    }

    public void ResetSession()          // ���� ���� �ʱ�ȭ
    {
        sessionScore = 0;
        sessionCoins = 0;
        UpdateUI();
    }

    // �ְ� ���� ���� & �ҷ�����
    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (sessionScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", sessionScore);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()   // �ְ� ���� �ҷ�����
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }
}
