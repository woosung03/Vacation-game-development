using UnityEngine;

public class ObstacleSpawner : MonoBehaviour    //장애물 생성자
{
    public GameObject[] obstacleGroups; // ObstacleGroup1~N 프리팹
    public Transform spawnPoint;            // 스폰 위치 (고정 오브젝트)
    public float spawnTriggerX = 0f; // 이전 장애물 오브젝트가 이 위치에 도달하면 다음 장애물 오브젝트생성

    private GameObject lastSpawned; // 마지막으로 생성된 장애물 오브젝트
    void Start()
    {
        SpawnObstacleGroup(); // 첫 장애물 생성
    }

    void Update()
    {
        if (lastSpawned == null) return;

        // 이전 장애물 오브젝트가 0에 도달하면 새 장애물 오브젝트생성
        if (lastSpawned.transform.position.x <= spawnTriggerX)
        {
            SpawnObstacleGroup();
        }
    }
    void SpawnObstacleGroup()
    {
        // 랜덤으로 그룹 선택
        int index = Random.Range(0, obstacleGroups.Length);
        GameObject group = Instantiate(obstacleGroups[index], spawnPoint.position, Quaternion.identity);

        // 안에 있는 Pattern 중 1개만 활성화  // 아직 오브젝트 하나당 패턴 하나
        int childCount = group.transform.childCount;
        int patternIndex = Random.Range(0, childCount);

        for (int i = 0; i < childCount; i++)
        {
            group.transform.GetChild(i).gameObject.SetActive(i == patternIndex);
        }

        lastSpawned = group;

        // 장애물 이동 컴포넌트에서 spawner 연결
        var mover = group.GetComponent<WorldObjectMover>();
        if (mover != null)
        {
            mover.spawner = this;
        }
    }
}
