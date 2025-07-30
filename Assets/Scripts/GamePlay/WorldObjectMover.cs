using UnityEngine;

public class WorldObjectMover : MonoBehaviour   // 모든 오브젝트 움직임
{
    public float speedMultiplier = 1.0f;  // 속도 비율 조정
    public ObstacleSpawner spawner;  // 장애물 스포너 참조
    void Update()
    {
        float moveSpeed = WorldSpeedManager.CurrentSpeed * speedMultiplier;   // 현재 이동 속도 설정

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // 왼쪽으로 이동

        if (transform.position.x < -16f)
        {
            gameObject.SetActive(false); // 파괴 대신 비활성화
            if (spawner != null)
            {
                spawner.NotifyObstacleCleared();  // 다음 장애물 요청
            }
        }
    }
}
