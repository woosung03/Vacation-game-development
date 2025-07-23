using System.Collections.Generic;
using UnityEngine;

public class CoinClass : MonoBehaviour  // 코인 클레스 관리 스크립트
{
    public static CoinClass Instance;

    public GameObject coinPrefab;   // 코인 프리팹
    public int ClassSize = 10;  // 클래스 크기

    private List<GameObject> coinClass = new List<GameObject>();    // 클래스 리스트

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < ClassSize; i++) // 코인 클래스 초기화
        {
            GameObject coin = Instantiate(coinPrefab);  // 코인 프리팹 인스턴스화
            coin.SetActive(false);  // 비활성화 상태로 설정
            coinClass.Add(coin);    // 클래스 리스트에 추가
        }
    }

    public GameObject GetCoin() // 코인 가져오기 메소드
    {
        foreach (var coin in coinClass) // 코인 클래스에서 비활성화된 코인 찾기
        {
            if (!coin.activeInHierarchy)    //  코인이 비활성화 상태라면
            {
                coin.SetActive(true);   // 활성화 상태로 변경
                return coin;    
            }
        }


        GameObject newCoin = Instantiate(coinPrefab);   // 새로운 코인 생성
        newCoin.SetActive(true);    // 활성화 상태로 설정
        coinClass.Add(newCoin); //  클래스 리스트에 추가
        return newCoin; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
