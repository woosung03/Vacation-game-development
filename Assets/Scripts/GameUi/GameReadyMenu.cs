using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyMenu : MonoBehaviour
{
    // '게임 시작' 버튼 클릭 시 호출
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameMain");
    }

    // '상점' 버튼 클릭 시 호출
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    // '점수 보기' 버튼 클릭 시 호출
    public void OnClickScore()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
