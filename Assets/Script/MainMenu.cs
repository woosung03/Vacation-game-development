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

    public void OnClickGameStart() // Start ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMain"); // ���� ����ȭ�鿡�� ���� ���� ȭ������
    }

    public void OnClickExit() // Exit ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    {
        // Exit the application
        Application.Quit();

        // If running in the editor, stop playing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
