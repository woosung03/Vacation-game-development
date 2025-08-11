using System.Collections.Generic;
using UnityEngine;

public class CoinClass : MonoBehaviour  // ���� Ŭ���� ���� ��ũ��Ʈ
{
    public static CoinClass Instance;

    public GameObject coinPrefab;   // ���� ������
    public int ClassSize = 10;  // Ŭ���� ũ��

    private List<GameObject> coinClass = new List<GameObject>();    // Ŭ���� ����Ʈ

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < ClassSize; i++) // ���� Ŭ���� �ʱ�ȭ
        {
            GameObject coin = Instantiate(coinPrefab);  // ���� ������ �ν��Ͻ�ȭ
            coin.SetActive(false);  // ��Ȱ��ȭ ���·� ����
            coinClass.Add(coin);    // Ŭ���� ����Ʈ�� �߰�
        }

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetCoin() // ���� �������� �޼ҵ�
    {
        foreach (var coin in coinClass) // ���� Ŭ�������� ��Ȱ��ȭ�� ���� ã��
        {
            if (!coin.activeInHierarchy)    //  ������ ��Ȱ��ȭ ���¶��
            {
                coin.SetActive(true);   // Ȱ��ȭ ���·� ����
                return coin;
            }
        }


        GameObject newCoin = Instantiate(coinPrefab);   // ���ο� ���� ����
        newCoin.SetActive(true);    // Ȱ��ȭ ���·� ����
        coinClass.Add(newCoin); //  Ŭ���� ����Ʈ�� �߰�
        return newCoin;
    }
}
