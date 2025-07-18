using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    public int coinValue = 1; // 코인 획득 시 증가하는 점수
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // 코인 태그가 있는 오브젝트와 충돌했을 때
        {
            CoinManager.Instance.AddCoins(coinValue);
            collision.gameObject.SetActive(false);  // 디스토이 대신 비활성화
        }
    }
}
