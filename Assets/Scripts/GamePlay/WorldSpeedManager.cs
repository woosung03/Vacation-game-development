using UnityEngine;

public static class WorldSpeedManager   //  전역 속도관리
{
    public static float CurrentSpeed   { get; private set; } = 2.0f;

    private static float maxSpeed = 10.0f;
    private static float acceleration = 0.2f; // 초당 증가량

    public static void UpdateSpeed(float deltaTime)
    {
        // 일정 시간마다 증가 
        CurrentSpeed = Mathf.Min(CurrentSpeed + acceleration * deltaTime, maxSpeed);
    }
}
