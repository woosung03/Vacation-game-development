using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 

    public int totalScore = 0;     // ���� ���� 
    public int currentScore = 0;   // �̹� ���� ����
    public int highScore = 0;      // �ְ� ����  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();    // �� ������ �ְ� ���� �ҷ�����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCurrentScore(int amount)
    {
        currentScore += amount;

        // �ְ� ���� ����
        if (currentScore > highScore)   // �ְ� �������� ���� ������ ���� ��
        {
            highScore = currentScore;
            SaveScore(); // ���̽��ھ ����
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
