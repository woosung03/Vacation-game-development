using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopButton : MonoBehaviour
{
    public TMP_Text coinText;

    public void OnClickUpgradeHealth()  //  체력업글
    {
        if (UpgradeManager.Instance.UpgradeHealth())
            UpdateUI();
    }

    public void OnClickUpgradeCoin()    //  코인업글
    {
        if (UpgradeManager.Instance.UpgradeCoin())
            UpdateUI();
    }

    public void OnClickUpgradeScore()   //  점수업글
    {
        if (UpgradeManager.Instance.UpgradeScore())
            UpdateUI();
    }

    public void OnClickBack() //  뒤로가기
    {
        SceneManager.LoadScene("GameReady");
    }
    private void UpdateUI() //  UI 업데이트
    {
        coinText.text = CoinManager.Instance.totalCoins.ToString();
    }  
}
