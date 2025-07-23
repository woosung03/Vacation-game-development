using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject scorePanel;
    public TMP_Text highScoreText;

    // '���� ����' ��ư Ŭ�� �� ȣ��
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameMain");
    }

    // '����' ��ư Ŭ�� �� ȣ��
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void OnClickScore()
    {
        // �� �̵� ��� �г� ��ȯ
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
