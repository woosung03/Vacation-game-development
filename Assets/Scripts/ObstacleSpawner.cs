using UnityEngine;

public class ObstacleSpawner : MonoBehaviour    //��ֹ� ������
{
    public GameObject[] obstacleGroups; // ObstacleGroup1~N ������
    public Transform spawnPoint;        // ��� ����
    public float spawnInterval = 10f;    // ���� ����
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacleGroup), 1f, spawnInterval);     // 1�� �ĺ��� spawnInterval �������� ��ֹ� �׷� ����
    }


    void SpawnObstacleGroup()
    {
        // �������� �׷� ����
        int index = Random.Range(0, obstacleGroups.Length);     
        GameObject group = Instantiate(obstacleGroups[index], spawnPoint.position, Quaternion.identity);

        // �ȿ� �ִ� Pattern �� 1���� Ȱ��ȭ
        int childCount = group.transform.childCount;
        int patternIndex = Random.Range(0, childCount);

        for (int i = 0; i < childCount; i++)
        {
            group.transform.GetChild(i).gameObject.SetActive(i == patternIndex);
        }
    }

}
