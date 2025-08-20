using UnityEngine;


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

    public bool UpgradeHealth()
    {
        int cost = healthLevel * 50;
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.SpendCoins(cost);
            healthLevel++;
            SaveUpgrades();
            return true;
        }
        return false;
    }

    public bool UpgradeCoin()
    {
        int cost = coinLevel * 50;
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.SpendCoins(cost);
            coinLevel++;
            SaveUpgrades();
            return true;
        }
        return false;
    }

    public bool UpgradeScore()
    {
        int cost = scoreLevel * 50;
        if (CoinManager.Instance.totalCoins >= cost)
        {
            CoinManager.Instance.SpendCoins(cost);
            scoreLevel++;
            SaveUpgrades();
            return true;
        }
        return false;
    }

    private void SaveUpgrades()
    {
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
        PlayerPrefs.SetInt("CoinLevel", coinLevel);
        PlayerPrefs.SetInt("ScoreLevel", scoreLevel);
        PlayerPrefs.Save();
    }

    private void LoadUpgrades()
    {
        healthLevel = PlayerPrefs.GetInt("HealthLevel", 1);
        coinLevel = PlayerPrefs.GetInt("CoinLevel", 1);
        scoreLevel = PlayerPrefs.GetInt("ScoreLevel", 1);
    }
}
