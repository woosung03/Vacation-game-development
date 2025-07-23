using UnityEngine;

public static class WorldSpeedManager   //  ���� �ӵ�����
{
    public static float CurrentSpeed   { get; private set; } = 2.0f;

    private static float maxSpeed = 10.0f;
    private static float acceleration = 0.2f; // �ʴ� ������

    public static void UpdateSpeed(float deltaTime)
    {
        // ���� �ð����� ���� 
        CurrentSpeed = Mathf.Min(CurrentSpeed + acceleration * deltaTime, maxSpeed);
    }
}
