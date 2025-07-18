using UnityEngine;

public class WorldObjectMover : MonoBehaviour
{
    public float speedMultiplier = 100.0f;  // 속도 비율 조정
    void Start()
    {
        
    }
    void Update()
    {
        float moveSpeed = BackGround_Move.CurrentSpeed * speedMultiplier;   // 현재 배경 속도에 비례하여 이동 속도 설정

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 왼쪽으로 이동

        if (transform.position.x < -20f)
        {
            gameObject.SetActive(false); // 파괴 대신 비활성화
        }
    }
}
