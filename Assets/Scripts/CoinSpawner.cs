using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float startInterval = 5.0f;     // ���� �� 5�ʿ� 1��
    public float minInterval = 1.5f;       // �ƹ��� ���� 1.5�� ����
    public float acceleration = 0.01f;     // �پ��� �ӵ��� �ſ� ����


    private float currentInterval;
    private float timer;

    void Start()
    {
        currentInterval = startInterval;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // ��� �ӵ� �������� ���� ���
        float currentSpeed = BackGround_Move.CurrentSpeed;
        float currentInterval = Mathf.Max(minInterval, startInterval - currentSpeed * 3f);

        if (timer >= currentInterval)
        {
            timer = 0f;
            SpawnCoin();
        }
    }

    void SpawnCoin()    // ���� ���� �޼ҵ�
    {
        GameObject coin = CoinClass.Instance.GetCoin();         // CoinClass���� ���� ������Ʈ�� ������

        float y = -3.5f + Random.Range(-0.5f, 0.5f);
        coin.transform.position = new Vector3(10f, y, 0f);
    }
}
