using UnityEngine;

public class WorldSpeedController : MonoBehaviour // ������Ʈ �ӵ� ��Ʈ�ѷ�
{
    public static WorldSpeedController Instance;

    void Update()
    {
        void Update()
        {
            WorldSpeedManager.UpdateSpeed(Time.deltaTime);
        }
    }
}
