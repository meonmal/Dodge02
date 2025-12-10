using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 초당 회전 속도
    public float rotationSpeed = 60f;

    private void Update()
    {
        // 이 스크립트를 갖고 있는 게임 오브젝트의 y축을 회전시킨다.
        // * Time.deltaTime을 해주지 않으면 초단위가 아니라 프레임 단위로 실행된다.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
