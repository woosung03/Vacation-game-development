using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int CurrentScore { get; private set; }
    public int CurrentCoins { get; private set; }
    public int HighScore { get; private set; }
    public int TotalCoins { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

    public void AddCoins(int amount)
    {
        CurrentCoins += amount;
        TotalCoins += amount;
    }

    public void ResetSession()
    {
        CurrentScore = 0;
        CurrentCoins = 0;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
