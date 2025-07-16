using UnityEngine;

public class WorldObjectMoveer : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 이동 속도
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(transform.position.x < -20f) // 화면 밖으로 나가면
        {
            Destroy(gameObject); // 오브젝트 제거
        }
    }
}
