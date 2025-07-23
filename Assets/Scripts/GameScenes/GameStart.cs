using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start ��ư Ŭ�� �� ȣ��
    public void OnClickGameStart()
    {
        // GameReady ������ �̵�
        SceneManager.LoadScene("GameReady");
    }

    // Exit ��ư Ŭ�� �� ȣ��
    public void OnClickExit()
    {
        // ���ø����̼� ����
        Application.Quit();

        // ����Ƽ �����Ϳ����� ���� ��� �÷��� ��� ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
