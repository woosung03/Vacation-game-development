using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public int healthLevel = 1;
    public int coinLevel = 1;
    public int scoreLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUpgrades();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnClickHealth()
    {
        int cost = healthLevel * 50; // 레벨별 가격
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.AddCoins(-cost); // 코인 차감
            healthLevel++;
            SaveUpgrades();
        }
    }

    public void OnClickCoin()
    {
        int cost = coinLevel * 50;
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.AddCoins(-cost);
            coinLevel++;
            SaveUpgrades();
        }
    }

    public void OnClickScore()
    {
        int cost = scoreLevel * 50;
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.AddCoins(-cost);
            scoreLevel++;
            SaveUpgrades();
        }
    }


    void SaveUpgrades()
    {
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
        PlayerPrefs.SetInt("CoinLevel", coinLevel);
        PlayerPrefs.SetInt("ScoreLevel", scoreLevel);
        PlayerPrefs.Save();
    }

    void LoadUpgrades()
    {
        healthLevel = PlayerPrefs.GetInt("HealthLevel", 1);
        coinLevel = PlayerPrefs.GetInt("CoinLevel", 1);
        scoreLevel = PlayerPrefs.GetInt("ScoreLevel", 1);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("GameReady");
    }
}
