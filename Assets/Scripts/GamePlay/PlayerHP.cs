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
    public int HP_Potion = 30; // 체력 포션

    private int currentHP;          // 현재 체력
    private Coroutine hpRoutine;    // 체력바 감소 루틴

    private GameOverUI gameOverUI;  // 게임오버 UI 참조

    private void Start()
    {
        maxHP = 100 + (UpgradeManager.Instance.healthLevel - 1) * 20; // 레벨당 20씩 증가
        currentHP = maxHP;          // 초기 체력 설정
        hpBar.maxValue = maxHP;     // 최대 체력 설정
        hpBar.value = currentHP;    // 현재 체력 설정

        gameOverUI = FindObjectOfType<GameOverUI>();    //  게임오버 UI 찾기 버그 확인용
        if (gameOverUI == null)
        {
            Debug.LogError("GameOverUI를 찾을 수 없습니다!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Obstacle"))   // 장애물과 충돌 시
        {
            TakeDamage(damageOnHit);
        }

        if(collision.CompareTag("HP_Potion")) // 체력 포션과 충돌 시
        {
            TakeHP_Potion(HP_Potion);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;    // 현재 체력바에서 체력 감소
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 체력 0 이하로 떨어지지 않도록 제한
        hpBar.value = currentHP;    // 체력바 업데이트

        if (currentHP <= 0) // 현재 체력이 0이 되면 다이함수
        {
            Die();
        }
    }

    void TakeHP_Potion(int hp)
    {
        currentHP += hp; // 체력 포션으로 체력 증가
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 최대 체력 초과하지 않도록 제한
        hpBar.value = currentHP; // 체력바 업데이트
    }

    void Die()
    {
        Debug.Log("플레이어 체력 0, Die() 호출됨"); // 뭐가 문제야
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();  // 매개변수 없는 오버로드 호출
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("gameOverUI가 null입니다.");
        }
    }

}
