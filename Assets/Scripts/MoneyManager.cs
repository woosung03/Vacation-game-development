using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int money = 0; // 게임 내 돈을 저장하는 정적 변수

    public static int highScore = 0; // 최고 점수를 저장하는 정적 변수

    public static int score = 0; // 현재 점수를 저장하는 정적 변수

    public static void AddMoney(int amount)
    {
        money += amount; // 돈을 추가  
    }
}
