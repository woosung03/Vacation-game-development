using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // �̱��� �ν��Ͻ�
    public int totalCoins = 0;  // �÷��̾� ���� ���� ��

    private void Awake()
    {
        if (Instance == null) // �̱��� ���� ����
        {
            Instance = this;    // �ν��Ͻ� �Ҵ�
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
            LoadCoins();    // ���� ������ �ε�
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddCoins(int amount)
    {
        totalCoins += amount;   // ���� �߰�
        SaveCoins();
    }

    void SaveCoins()    // ���� ����
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    void LoadCoins()    // ���� �ε�
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
