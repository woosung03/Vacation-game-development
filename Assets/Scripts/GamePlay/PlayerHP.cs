using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;    // 플레이어 체력 슬라이더 UI
    public int baseMaxHP = 100; // 기본 최대 체력
    private int currentHP;  // 인게임 체력

    private float elapsedTime = 0f;     // 경과 시간
    private int damageIncrease = 1;   // 데미지 배율 (시간에 따라 증가)


    private void Start()
    {
        if (hpBar == null)
        {
            hpBar = GameObject.Find("HP_Slider")?.GetComponent<Slider>();
            if (hpBar == null) Debug.LogError("HP Slider를 찾을 수 없습니다!");
        }

        // 체력 업그레이드 반영
        int maxHP = baseMaxHP + (UpgradeManager.Instance.healthLevel - 1) * 20;
        currentHP = maxHP;

        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }

    private void Update()   // 데미지 계산용 타이머
    {
        // 시간 경과 체크
        elapsedTime += Time.deltaTime;

        // 10초마다 데미지 배율 +1
        if (elapsedTime >= 10f)
        {
            damageIncrease++;
            elapsedTime = 0f;  // 다시 카운트
            Debug.Log($"데미지 배율 증가! 현재 배율: {damageIncrease}");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 플레이어가 충돌했을 때 호출되는 함수 1
    {
        if (collision.CompareTag("Obstacle"))   // 장애물 태그 확인
        {
            TakeDamage(1 * damageIncrease); 
        }
    }
    public void TakeDamage(int dmg) // 플레이어가 피해를 입었을 때 호출되는 함수 2
    {
        currentHP -= dmg;
        currentHP = (int)Mathf.Clamp(currentHP, 0, hpBar.maxValue);
        hpBar.value = currentHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()  // 플레이어 체력 0일 때 호출ㄹ
    {
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();   // 점수/코인 자동 가져오는 버전 호출
        }
        else
        {
            Debug.LogError("GameOverUI를 씬에서 찾을 수 없습니다!");
        }
    }

}
