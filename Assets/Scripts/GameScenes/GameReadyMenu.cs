using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject scorePanel;
    public TMP_Text highScoreText;

    // '게임 시작' 버튼 클릭 시 호출
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameMain");
    }

    // '상점' 버튼 클릭 시 호출
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void OnClickScore()
    {
        // 씬 이동 대신 패널 전환
        mainPanel.SetActive(false);
        scorePanel.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    public void OnClickBack()
    {
        scorePanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
