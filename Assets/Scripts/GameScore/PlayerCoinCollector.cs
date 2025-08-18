using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour    // 플레이어 코인 수집기
{
    public int coinValue = 1; // 코인 획득 시 증가하는 점수 

    public GameSessionUI sessionUI;  // GameSessionUI 참조 변수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))   // 코인 태그가 있는 오브젝트와 충돌했을 때
        {
            int bonus = UpgradeManager.Instance.coinLevel - 1;
            int finalCoin = coinValue + bonus;

            CoinManager.Instance.AddCoins(finalCoin);   // 상점용 코인 증가

            if (sessionUI != null)
            {
                ScoreManager.Instance.AddCoins(finalCoin);         // UI용 코인 증가
                ScoreManager.Instance.AddScore(finalCoin * 10);    // 점수 증가
                collision.gameObject.SetActive(false);
            }
        }
        else if (collision.CompareTag("ScoreItem"))
        {
            int multiplier = UpgradeManager.Instance.scoreLevel;
            int finalScore = 50 * multiplier; // 업그레이드 레벨만큼 배수 적용
            ScoreManager.Instance.AddScore(finalScore);
            collision.gameObject.SetActive(false);
        }
    }
}
