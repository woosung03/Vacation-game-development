using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;
    public int maxHP = 100;         // 최대 체력
    public int damageOnHit = 10;    // 충돌 시 받는 피해
    public float hpLerpSpeed = 5f;  // 체력바 감소 속도

    private int currentHP;          // 현재 체력
    private Coroutine hpRoutine;    // 체력바 감소 루틴

    private void Start()
    {
        currentHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))   // 장애물과 충돌 시
        {
            TakeDamage(damageOnHit);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;    // 현재 체력바에서 체력 감소
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 체력 0 이하로 떨어지지 않도록 제한
        hpBar.value = currentHP;    // 체력바 업데이트

        if (currentHP <= 0) // 현재 체력이 0이 되면 게임 레디 씬으로 넘어가기
        {
            SceneManager.LoadScene("GameReady");
        }
    }

}
