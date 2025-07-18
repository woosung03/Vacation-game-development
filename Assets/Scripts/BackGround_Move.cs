using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float speed;        // 초기 속도
    public float acceleration = 0.01f; // 시간당 증가 속도
    public float maxSpeed = 1.0f;      // 최대 속도 제한

    private float offsetX = 0f;

    public static float CurrentSpeed 
    { 
        get; private set; 
    }  //  현재 속도 외부 접근용

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        speed = Mathf.Min(speed, maxSpeed);     // 최대 속도 제한

        speed += acceleration * Time.deltaTime; // 매 프레임 속도 증가
        offsetX += speed * Time.deltaTime;      // 이동 거리 계산
        meshRenderer.material.mainTextureOffset = new Vector2(offsetX, 0);

        CurrentSpeed = speed; //  현재 속도 저장
    }
}
