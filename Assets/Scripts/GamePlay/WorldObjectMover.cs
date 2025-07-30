using UnityEngine;

public class WorldObjectMover : MonoBehaviour   // ��� ������Ʈ ������
{
    public float speedMultiplier = 1.0f;  // �ӵ� ���� ����
    public ObstacleSpawner spawner;  // ��ֹ� ������ ����
    void Update()
    {
        float moveSpeed = WorldSpeedManager.CurrentSpeed * speedMultiplier;   // ���� �̵� �ӵ� ����

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // �������� �̵�

        if (transform.position.x < -16f)
        {
            gameObject.SetActive(false); // �ı� ��� ��Ȱ��ȭ
            if (spawner != null)
            {
                spawner.NotifyObstacleCleared();  // ���� ��ֹ� ��û
            }
        }
    }
}
