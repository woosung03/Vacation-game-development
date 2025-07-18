using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float startInterval = 5.0f;     // 시작 시 5초에 1개
    public float minInterval = 1.5f;       // 아무리 빨라도 1.5초 간격
    public float acceleration = 0.01f;     // 줄어드는 속도를 매우 낮게


    private float currentInterval;
    private float timer;

    void Start()
    {
        currentInterval = startInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 배경 속도 기준으로 간격 계산
        float currentSpeed = BackGround_Move.CurrentSpeed;
        float currentInterval = Mathf.Max(minInterval, startInterval - currentSpeed * 3f);

        if (timer >= currentInterval)
        {
            timer = 0f;
            SpawnCoin();
        }
    }

    void SpawnCoin()    // 코인 생성 메소드
    {
        GameObject coin = CoinClass.Instance.GetCoin();         // CoinClass에서 코인 오브젝트를 가져옴

        float y = -3.5f + Random.Range(-0.5f, 0.5f);
        coin.transform.position = new Vector3(10f, y, 0f);
    }
}
