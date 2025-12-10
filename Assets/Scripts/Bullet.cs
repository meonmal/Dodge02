using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 총알의 이동 속도
    public float speed;

    // 총알의 리지드바디
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        // 리지드바디 컴포넌트 가져오기
        bulletRigidbody = GetComponent<Rigidbody>();
        // 총알의 리지드바디를 이용해 움직이게 만든다. 방향은 총알의 앞쪽 방향이다.
        bulletRigidbody.linearVelocity = transform.forward * speed;
        // 3초 뒤에 게임 오브젝트를 삭제시킨다.
        Destroy(gameObject, 3f);
    }

    // 트리거로 닿으면 실행되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 만약 닿은 게임 오브젝트의 태그가 Player라면 실행
        if(other.tag == "Player")
        {
            // 닿은 게임 오브젝트에게 PlayerController 컴포넌트 가져오기
            PlayerController playerController = GetComponent<PlayerController>();

            // 만약 PlayerController를 성공적으로 가져왔다면 실행
            if(playerController != null)
            {
                // PlayerController에 있는 Die() 함수 실행
                playerController.Die();
            }
        }
    }
}
