using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // �÷��̾� ���� ������
{
    public int coinValue = 1; // ���� ȹ�� �� �����ϴ� ���� 

    public GameSessionUI sessionUI;  // GameSessionUI ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // ���� �±װ� �ִ� ������Ʈ�� �浹���� ��
        {
            int bonus = UpgradeManager.Instance.coinLevel - 1;
            int finalCoin = coinValue + bonus;

            CoinManager.Instance.AddCoins(finalCoin);   // ������ ���� ����

            if (sessionUI != null)
            {
                ScoreManager.Instance.AddCoins(finalCoin);         // UI�� ���� ����
                ScoreManager.Instance.AddScore(finalCoin * 10);    // ���� ����
                collision.gameObject.SetActive(false);
            }
        }
        else if (collision.CompareTag("ScoreItem"))
        {
            int multiplier = UpgradeManager.Instance.scoreLevel;
            int finalScore = 50 * multiplier; // ���׷��̵� ������ŭ ��� ����
            ScoreManager.Instance.AddScore(finalScore);
            collision.gameObject.SetActive(false);
        }
    }
}
