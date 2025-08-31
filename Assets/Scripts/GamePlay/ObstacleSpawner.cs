using UnityEngine;

public class ObstacleSpawner : MonoBehaviour    //��ֹ� ������
{
    public GameObject[] obstacleGroups; // ObstacleGroup1~N ������
    public Transform spawnPoint;            // ���� ��ġ (���� ������Ʈ)
    public float spawnTriggerX = 0f; // ���� ��ֹ� ������Ʈ�� �� ��ġ�� �����ϸ� ���� ��ֹ� ������Ʈ����

    private GameObject lastSpawned; // ���������� ������ ��ֹ� ������Ʈ
    void Start()
    {
        SpawnObstacleGroup(); // ù ��ֹ� ����
    }

    void Update()
    {
        if (lastSpawned == null) return;

        // ���� ��ֹ� ������Ʈ�� 0�� �����ϸ� �� ��ֹ� ������Ʈ����
        if (lastSpawned.transform.position.x <= spawnTriggerX)
        {
            SpawnObstacleGroup();
        }
    }
    void SpawnObstacleGroup()
    {
        // �������� �׷� ����
        int index = Random.Range(0, obstacleGroups.Length);
        GameObject group = Instantiate(obstacleGroups[index], spawnPoint.position, Quaternion.identity);

        // �ȿ� �ִ� Pattern �� 1���� Ȱ��ȭ  // ���� ������Ʈ �ϳ��� ���� �ϳ�
        int childCount = group.transform.childCount;
        int patternIndex = Random.Range(0, childCount);

        for (int i = 0; i < childCount; i++)
        {
            group.transform.GetChild(i).gameObject.SetActive(i == patternIndex);
        }

        lastSpawned = group;

        // ��ֹ� �̵� ������Ʈ���� spawner ����
        var mover = group.GetComponent<WorldObjectMover>();
        if (mover != null)
        {
            mover.spawner = this;
        }
    }
}
