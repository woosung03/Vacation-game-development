using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;
    public int maxHP = 100;         // �ִ� ü��
    public int damageOnHit = 10;    // �浹 �� �޴� ����
    public float hpLerpSpeed = 5f;  // ü�¹� ���� �ӵ�

    private int currentHP;          // ���� ü��
    private Coroutine hpRoutine;    // ü�¹� ���� ��ƾ

    private GameOverUI gameOverUI;  // ���ӿ��� UI ����

    private void Start()
    {
        currentHP = maxHP;          // �ʱ� ü�� ����
        hpBar.maxValue = maxHP;     // �ִ� ü�� ����
        hpBar.value = currentHP;    // ���� ü�� ����

        gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI == null)
        {
            Debug.LogError("GameOverUI�� ã�� �� �����ϴ�!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))   // ��ֹ��� �浹 ��
        {
            TakeDamage(damageOnHit);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;    // ���� ü�¹ٿ��� ü�� ����
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // ü�� 0 ���Ϸ� �������� �ʵ��� ����
        hpBar.value = currentHP;    // ü�¹� ������Ʈ

        if (currentHP <= 0) // ���� ü���� 0�� �Ǹ� �����Լ�
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("�÷��̾� ü�� 0, Die() ȣ���");
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();  // �Ű����� ���� �����ε� ȣ��
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("gameOverUI�� null�Դϴ�.");
        }
    }

}
