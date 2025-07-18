using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    public int coinValue = 1; // ���� ȹ�� �� �����ϴ� ����
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // ���� �±װ� �ִ� ������Ʈ�� �浹���� ��
        {
            CoinManager.Instance.AddCoins(coinValue);
            collision.gameObject.SetActive(false);  // ������ ��� ��Ȱ��ȭ
        }
    }
}
