using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // 플레이어 코인 수집기
{
    public int coinValue = 1; // 코인 획득 시 증가하는 점수 // 나중에 상점에서 업글 할 때 사용

    public GameSessionUI sessionUI;  // GameSessionUI 참조 변수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // 코인 태그가 있는 오브젝트와 충돌했을 때
        {
            CoinManager.Instance.AddCoins(coinValue);   // 전체 코인 저장 (상점용)

            if (sessionUI != null)
            {
                sessionUI.AddCoin(coinValue);           // 세션 UI 코인 업데이트
                sessionUI.AddScore(coinValue * 10);     // 세션 UI 점수 업데이트 (코인 1개당 10점)
            }

            collision.gameObject.SetActive(false);      // 디스트로이 대신 비활성화
        }
        else if (collision.CompareTag("ScoreItem"))
        {
            int bonusScore = 50; // 점수 오브젝트 

            if (sessionUI != null)
            {
                sessionUI.AddScore(bonusScore); // 세션 UI 점수 업데이트
            }
            collision.gameObject.SetActive(false);  // 디스트로이 대신 비활성화
        }
    }
}
