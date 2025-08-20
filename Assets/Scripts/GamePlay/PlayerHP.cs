using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;    // �÷��̾� ü�� �����̴� UI
    public int baseMaxHP = 100; // �⺻ �ִ� ü��
    private int currentHP;  // �ΰ��� ü��

    private float elapsedTime = 0f;     // ��� �ð�
    private int damageIncrease = 1;   // ������ ���� (�ð��� ���� ����)


    private void Start()
    {
        if (hpBar == null)
        {
            hpBar = GameObject.Find("HP_Slider")?.GetComponent<Slider>();
            if (hpBar == null) Debug.LogError("HP Slider�� ã�� �� �����ϴ�!");
        }

        // ü�� ���׷��̵� �ݿ�
        int maxHP = baseMaxHP + (UpgradeManager.Instance.healthLevel - 1) * 20;
        currentHP = maxHP;

        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }

    private void Update()   // ������ ���� Ÿ�̸�
    {
        // �ð� ��� üũ
        elapsedTime += Time.deltaTime;

        // 10�ʸ��� ������ ���� +1
        if (elapsedTime >= 10f)
        {
            damageIncrease++;
            elapsedTime = 0f;  // �ٽ� ī��Ʈ
            Debug.Log($"������ ���� ����! ���� ����: {damageIncrease}");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // �÷��̾ �浹���� �� ȣ��Ǵ� �Լ� 1
    {
        if (collision.CompareTag("Obstacle"))   // ��ֹ� �±� Ȯ��
        {
            TakeDamage(1 * damageIncrease); 
        }
    }
    public void TakeDamage(int dmg) // �÷��̾ ���ظ� �Ծ��� �� ȣ��Ǵ� �Լ� 2
    {
        currentHP -= dmg;
        currentHP = (int)Mathf.Clamp(currentHP, 0, hpBar.maxValue);
        hpBar.value = currentHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()  // �÷��̾� ü�� 0�� �� ȣ�⤩
    {
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();   // ����/���� �ڵ� �������� ���� ȣ��
        }
        else
        {
            Debug.LogError("GameOverUI�� ������ ã�� �� �����ϴ�!");
        }
    }

}
