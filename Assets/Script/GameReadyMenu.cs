using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReadyMenu : MonoBehaviour
{
    // '���� ����' ��ư Ŭ�� �� ȣ��
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameMain");
    }

    // '����' ��ư Ŭ�� �� ȣ��
    public void OnClickShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    // '���� ����' ��ư Ŭ�� �� ȣ��
    public void OnClickScore()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
