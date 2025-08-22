using TMPro;
using UnityEngine;

public class GameSessionUI : MonoBehaviour  // 인게임 UI 관리 스크립트
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
