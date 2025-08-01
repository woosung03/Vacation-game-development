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
                sessionUI.AddCoin(coinValue);           // ���� UI ���� ������Ʈ
                sessionUI.AddScore(coinValue * 10);     // ���� UI ���� ������Ʈ (���� 1���� 10��)
            }

            collision.gameObject.SetActive(false);      // ��Ʈ���� ��� ��Ȱ��ȭ
        }
        else if (collision.CompareTag("ScoreItem"))
        {
            int bonusScore = 50; // ���� ������Ʈ 

            if (sessionUI != null)
            {
                sessionUI.AddScore(bonusScore); // ���� UI ���� ������Ʈ
            }
            collision.gameObject.SetActive(false);  // ��Ʈ���� ��� ��Ȱ��ȭ
        }
    }
}
