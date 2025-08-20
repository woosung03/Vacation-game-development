using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopButton : MonoBehaviour
{
    public TMP_Text coinText;

    public void OnClickUpgradeHealth()  //  ü�¾���
    {
        if (UpgradeManager.Instance.UpgradeHealth())
            UpdateUI();
    }

    public void OnClickUpgradeCoin()    //  ���ξ���
    {
        if (UpgradeManager.Instance.UpgradeCoin())
            UpdateUI();
    }

    public void OnClickUpgradeScore()   //  ��������
    {
        if (UpgradeManager.Instance.UpgradeScore())
            UpdateUI();
    }

    public void OnClickBack() //  �ڷΰ���
    {
        SceneManager.LoadScene("GameReady");
    }
    private void UpdateUI() //  UI ������Ʈ
    {
        coinText.text = CoinManager.Instance.totalCoins.ToString();
    }  
}
