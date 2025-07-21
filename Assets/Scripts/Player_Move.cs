using UnityEngine;

public class Player_J : MonoBehaviour
{
    Rigidbody2D PlayerRB;

    public float JumpForce = 5f;

    private int jumpCount = 0;         //   현재 점프 횟수
    public int maxJumpCount = 2;       //   최대 점프 가능 횟수

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, 0f); // 캐릭터 y속도 제거
            PlayerRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // 땅에 닿으면 점프 횟수 초기화
        }
    }
}
