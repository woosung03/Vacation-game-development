using UnityEngine;

public class MoneyManager : MonoBehaviour   // 돈 관리 클래스 //아직 사용하지 않음
{
    public static int money = 0; // 게임 내 돈을 저장하는 정적 변수

    public static int highScore = 0; // 최고 점수를 저장하는 정적 변수

    public static int score = 0; // 현재 점수를 저장하는 정적 변수

    public static void AddMoney(int amount)
    {
        money += amount; // 돈을 추가  
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
