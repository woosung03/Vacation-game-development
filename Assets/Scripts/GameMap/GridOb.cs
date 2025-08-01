using UnityEngine;
using UnityEditor;

public class GridOb : MonoBehaviour // ������ �� �ڵ����� ��ũ��Ʈ
{
    public GameObject prefabToPlace; // ���� �Ǵ� ���� ������
    public int count = 5;            // ������ ����
    public Vector2 gridStart = Vector2.zero; // ���� ��ġ
    public Vector2Int direction = Vector2Int.right; // ��ġ ���� (���η�)
    public float gridSize = 1.0f;    // ���� ���� (1�̸� (1, 0), (2, 0) �̷� ��)

    [ContextMenu("���ڿ� ���� �ڵ� ��ġ")]
    void PlaceOnGrid()
    {
        if (prefabToPlace == null)
        {
            Debug.LogWarning("�������� �����ϴ�.");
            return;
        }

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(
                gridStart.x + direction.x * i * gridSize,
                gridStart.y + direction.y * i * gridSize,
                0f
            );

            GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(prefabToPlace);
            obj.transform.SetParent(transform);
            obj.transform.localPosition = pos;
        }
    }
}
