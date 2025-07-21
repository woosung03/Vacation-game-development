using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // 플레이어 코인 수집기
{
    public int coinValue = 1; // 코인 획득 시 증가하는 점수 // 나중에 상점에서 업글 할 때 사용

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // 코인 태그가 있는 오브젝트와 충돌했을 때
        {
            CoinManager.Instance.AddCoins(coinValue);
            collision.gameObject.SetActive(false);  // 디스트로이 대신 비활성화
        }
    }
}
