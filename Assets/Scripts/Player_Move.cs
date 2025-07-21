using UnityEngine;

public class Player_J : MonoBehaviour
{
    Rigidbody2D PlayerRB;

    public float JumpForce = 5f;

    private int jumpCount = 0;         // ���� ���� Ƚ��
    public int maxJumpCount = 2;       // �ִ� ���� ���� Ƚ��

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, 0f); // ���� y�ӵ� ����
            PlayerRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // ���� ������ ���� Ƚ�� �ʱ�ȭ
        }
    }
}
