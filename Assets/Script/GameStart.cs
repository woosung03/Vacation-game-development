using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start 버튼 클릭 시 호출
    public void OnClickGameStart()
    {
        // GameReady 씬으로 이동
        SceneManager.LoadScene("GameReady");
    }

    // Exit 버튼 클릭 시 호출
    public void OnClickExit()
    {
        // 애플리케이션 종료
        Application.Quit();

        // 유니티 에디터에서는 종료 대신 플레이 모드 중지
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
