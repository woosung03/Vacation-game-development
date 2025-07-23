using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // �÷��̾� ���� ������
{
    public int coinValue = 1; // ���� ȹ�� �� �����ϴ� ���� // ���߿� �������� ���� �� �� ���

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // ���� �±װ� �ִ� ������Ʈ�� �浹���� ��
        {
            CoinManager.Instance.AddCoins(coinValue);
            collision.gameObject.SetActive(false);  // ��Ʈ���� ��� ��Ȱ��ȭ
        }
    }
}
