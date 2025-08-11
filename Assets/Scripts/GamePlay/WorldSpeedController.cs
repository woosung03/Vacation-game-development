using UnityEngine;

public class WorldSpeedController : MonoBehaviour // 오브젝트 속도 컨트롤러
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
