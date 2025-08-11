using UnityEngine;

public class WorldSpeedController : MonoBehaviour // ������Ʈ �ӵ� ��Ʈ�ѷ�
{
    public static WorldSpeedController Instance;

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
    void Update()
    {
        void Update()
        {
            WorldSpeedManager.UpdateSpeed(Time.deltaTime);
        }
    }
}
