using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float speed;        // �ʱ� �ӵ�
    public float acceleration = 0.01f; // �ð��� ���� �ӵ�
    public float maxSpeed = 1.0f;      // �ִ� �ӵ� ����

    private float offsetX = 0f;

    public static float CurrentSpeed 
    { 
        get; private set; 
    }  //  ���� �ӵ� �ܺ� ���ٿ�

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        speed = Mathf.Min(speed, maxSpeed);     // �ִ� �ӵ� ����

        speed += acceleration * Time.deltaTime; // �� ������ �ӵ� ����
        offsetX += speed * Time.deltaTime;      // �̵� �Ÿ� ���
        meshRenderer.material.mainTextureOffset = new Vector2(offsetX, 0);

        CurrentSpeed = speed; //  ���� �ӵ� ����
    }
}
