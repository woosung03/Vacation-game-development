using UnityEngine;

public class WorldObjectMoveer : MonoBehaviour
{
    public float moveSpeed = 1.0f; // �̵� �ӵ�
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < -20f) // ȭ�� ������ ������
        {
            Destroy(gameObject); // ������Ʈ ����
        }
    }
}
