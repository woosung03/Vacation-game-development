using UnityEngine;

public static class WorldSpeedManager   // ���� �ӵ� ���� Ŭ����
{
    public static float CurrentSpeed   { get; private set; } = 5.0f;    //  ���� �ӵ�

    private static float maxSpeed = 30.0f;  // �ִ� �ӵ�
    private static float acceleration = 0.3f; // �ʴ� ������

    public static void UpdateSpeed(float deltaTime)
    {
        // ���� �ð����� ���� 
        CurrentSpeed = Mathf.Min(CurrentSpeed + acceleration * deltaTime, maxSpeed);
    }
}
