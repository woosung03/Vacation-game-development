using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGameStart() // Start 버튼 클릭 시 호출되는 함수
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMain"); // 게임 시작화면에서 게임 메인 화면으로
    }

    public void OnClickExit() // Exit 버튼 클릭 시 호출되는 함수
    {
        // Exit the application
        Application.Quit();

        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
