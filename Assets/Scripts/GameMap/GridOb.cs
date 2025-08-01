using UnityEngine;
using UnityEditor;

public class GridOb : MonoBehaviour // 프리펩 맵 자동생성 스크립트
{
    public GameObject prefabToPlace; // 코인 또는 점수 프리팹
    public int count = 5;            // 생성할 개수
    public Vector2 gridStart = Vector2.zero; // 시작 위치
    public Vector2Int direction = Vector2Int.right; // 배치 방향 (가로로)
    public float gridSize = 1.0f;    // 격자 간격 (1이면 (1, 0), (2, 0) 이런 식)

    [ContextMenu("격자에 맞춰 자동 배치")]
    void PlaceOnGrid()
    {
        if (prefabToPlace == null)
        {
            Debug.LogWarning("프리팹이 없습니다.");
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
