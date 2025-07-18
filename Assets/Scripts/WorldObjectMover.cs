using UnityEngine;

public class WorldObjectMover : MonoBehaviour
{
    public float speedMultiplier = 100.0f;  // �ӵ� ���� ����
    void Start()
    {
        
    }
    void Update()
    {
        float moveSpeed = BackGround_Move.CurrentSpeed * speedMultiplier;   // ���� ��� �ӵ��� ����Ͽ� �̵� �ӵ� ����

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // �������� �̵�

        if (transform.position.x < -20f)
        {
            gameObject.SetActive(false); // �ı� ��� ��Ȱ��ȭ
        }
    }
}
