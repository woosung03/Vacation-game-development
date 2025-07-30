using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody2D PlayerRB;

    public float JumpForce = 20f; // 플레이어 점프 힘
    public float gravityScale = 3f; // 플레이어 중력 스케일

    private int jumpCount = 0;         //   현재 점프 횟수
    public int maxJumpCount = 2;       //   최대 점프 가능 횟수

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerRB.gravityScale = gravityScale; // 중력 설정
    }


    void Update()
    {
        // 장애물 속도에 따라 점프.중력힘 조정
        float currentSpeed = WorldSpeedManager.CurrentSpeed;    // 장애물 현재 속도 가져오기
        JumpForce = 10f + currentSpeed * 1.5f;

        // 중력을 서서히 증가시킴
        float targetGravity = 4f + currentSpeed * 0.6f;
        PlayerRB.gravityScale = Mathf.Lerp(PlayerRB.gravityScale, targetGravity, Time.deltaTime * 3f);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, 0f); // 캐릭터 y속도 제거
            PlayerRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jumpCount++;    // 스페이스 키를 눌렀을 때 점프 횟수 증가
        }

        // 스페이스 키를 떼었을 때 플레이어 점프 속도 줄임
        if (Input.GetKeyUp(KeyCode.Space) && PlayerRB.linearVelocity.y > 0)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, PlayerRB.linearVelocity.y * 0.5f);
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
