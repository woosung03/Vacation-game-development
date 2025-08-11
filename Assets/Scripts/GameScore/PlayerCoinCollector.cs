using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // �÷��̾� ���� ������
{
    public int coinValue = 1; // ���� ȹ�� �� �����ϴ� ���� // ���߿� �������� ���� �� �� ���

    public GameSessionUI sessionUI;  // GameSessionUI ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // ���� �±װ� �ִ� ������Ʈ�� �浹���� ��
        {
            CoinManager.Instance.AddCoins(coinValue);   // ��ü ���� ���� (������)

            if (sessionUI != null)
            {
                ScoreManager.Instance.AddCoins(coinValue);           // ���� UI ���� ������Ʈ
                ScoreManager.Instance.AddScore(coinValue * 10);     // ���� UI ���� ������Ʈ (���� 1���� 10��)
                collision.gameObject.SetActive(false);              // ��Ʈ���� ��� ��Ȱ��ȭ
            }   
        }
        else if (collision.CompareTag("ScoreItem"))
        {
            ScoreManager.Instance.AddScore(50);     // ���� ȹ�� �� 50�� �߰�
            collision.gameObject.SetActive(false);  // ��Ʈ���� ��� ��Ȱ��ȭ
        }
    }
}
