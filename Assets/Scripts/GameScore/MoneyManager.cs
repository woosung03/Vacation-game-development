using UnityEngine;

public class MoneyManager : MonoBehaviour   // �� ���� Ŭ���� //���� ������� ����
{
    public static int money = 0; // ���� �� ���� �����ϴ� ���� ����

    public static int highScore = 0; // �ְ� ������ �����ϴ� ���� ����

    public static int score = 0; // ���� ������ �����ϴ� ���� ����

    public static void AddMoney(int amount)
    {
        money += amount; // ���� �߰�  
    }

    public static MoneyManager Instance;

    private void Awake()
    {
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
}
