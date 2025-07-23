using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // 싱글톤 인스턴스
    public int totalCoins = 0;  // 플래이어 지갑 코인 수

    private void Awake()
    {
        if (Instance == null) // 싱글톤 패턴 구현
        {
            Instance = this;    // 인스턴스 할당
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
            LoadCoins();    // 코인 데이터 로드
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddCoins(int amount)
    {
        totalCoins += amount;   // 코인 추가
        SaveCoins();
    }

    void SaveCoins()    // 코인 저장
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

    void LoadCoins()    // 코인 로드
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
