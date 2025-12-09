using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어의 이동 속도
    public float speed;

    // 플레이어의 리지드바디 컴포넌트
    private Rigidbody playerRigidbody;

    private void Start()
    {
        // 플레이어의 리지드바디 컴포넌트 가져오기
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 수평과 수직축의 입력값 가져오기
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        // 가져온 입력값에 speed를 곱해준다.
        float xMove = xInput * speed;
        float zMove = zInput * speed;

        // Vector3의 속도를 정해주고
        Vector3 newVelocity = new Vector3(xMove, 0, zMove);

        // 정해준 속도를 리지드바디에 입혀준다.
        playerRigidbody.linearVelocity = newVelocity;
    }
}
