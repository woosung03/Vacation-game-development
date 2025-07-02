using UnityEngine;

public class Player_J : MonoBehaviour
{
    Rigidbody2D PlayerRB;

    public float JumpForce = 5f;
    private bool isGrounded;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, 0f);
            PlayerRB.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
