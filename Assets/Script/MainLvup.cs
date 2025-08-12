using TMPro;
using UnityEngine;

public class MainLvup : MonoBehaviour
{
    public TMP_Text HPtext;
    public TMP_Text Cointext;
    public TMP_Text Scoretext;
    private int HPlv;
    private int Coinlv;
    private int Scorelv;
    void Start()
    {
        HPlv = PlayerPrefs.GetInt("HPlv", 1);
        Coinlv = PlayerPrefs.GetInt("Coinlv", 1);
        Scorelv = PlayerPrefs.GetInt("Scorelv", 1);
        UpdateHP();
        UpdateCoin();
        UpdateScore();
    }
    public void HPup()
    {
        HPlv += 1;
        //maxHP += 1; //최대HP 증가
        PlayerPrefs.SetInt("HPlv", HPlv); // 값 저장
        PlayerPrefs.Save();
        UpdateHP();
    }
    public void Coinup()
    {
        Coinlv += 1;
        //AddCoins.amount += 1; //코인 획득량 증가
        PlayerPrefs.SetInt("Coinlv", Coinlv);
        PlayerPrefs.Save();
        UpdateCoin();
    }
    public void Scoreup()
    {
        Scorelv += 1;
        //AddScore.amount +=1; //점수 획득량 증가
        PlayerPrefs.SetInt("Scorelv", Scorelv);
        PlayerPrefs.Save();
        UpdateScore();
    }
    private void UpdateHP()
    {
        HPtext.text = "HP Lv." + HPlv;
    }
    private void UpdateCoin()
    {
        Cointext.text = "Coin Lv." + Coinlv;
    }
    private void UpdateScore()
    {
        Scoretext.text = "Score Lv." + Scorelv;
    }
}
