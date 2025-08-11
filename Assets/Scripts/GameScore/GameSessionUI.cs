using TMPro;
using UnityEngine;

public class GameSessionUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinText;

    void Update()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.CurrentScore;
        coinText.text = "Coins: " + ScoreManager.Instance.CurrentCoins;
    }

    public int GetCoins()
    {
        return ScoreManager.Instance.CurrentCoins;
    }
}
