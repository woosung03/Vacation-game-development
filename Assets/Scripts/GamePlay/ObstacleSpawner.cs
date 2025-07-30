using UnityEngine;

public class ObstacleSpawner : MonoBehaviour    //장애물 생성자
{
    public GameObject[] obstacleGroups; // ObstacleGroup1~N 프리팹
    public float spawnInterval = 12f;    // 장애물 프리펩 생성 간격
    public Transform spawnPoint;            // 스폰 위치 (고정 오브젝트)

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacleGroup), 1f, spawnInterval);     // 1초 후부터 spawnInterval 간격으로 장애물 그룹 생성
    }


    void SpawnObstacleGroup()
    {
        // 랜덤으로 그룹 선택
        int index = Random.Range(0, obstacleGroups.Length);
        GameObject group = Instantiate(obstacleGroups[index], spawnPoint.position, Quaternion.identity);

        // 안에 있는 Pattern 중 1개만 활성화
        int childCount = group.transform.childCount;
        int patternIndex = Random.Range(0, childCount);

        for (int i = 0; i < childCount; i++)
        {
            group.transform.GetChild(i).gameObject.SetActive(i == patternIndex);
        }
    }

}
