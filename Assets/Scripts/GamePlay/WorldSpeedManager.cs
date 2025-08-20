using UnityEngine;

public static class WorldSpeedManager   // 전역 속도 관리 클래스
{
    public static float CurrentSpeed   { get; private set; } = 5.0f;    //  현재 속도

    private static float maxSpeed = 30.0f;  // 최대 속도
    private static float acceleration = 0.3f; // 초당 증가량

    public static void UpdateSpeed(float deltaTime)
    {
        // 일정 시간마다 증가 
        CurrentSpeed = Mathf.Min(CurrentSpeed + acceleration * deltaTime, maxSpeed);
    }
}
