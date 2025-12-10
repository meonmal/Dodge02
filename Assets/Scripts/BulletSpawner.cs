using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // 총알 프리팹
    public GameObject bulletPrefab;
    // 최소 소환 시간
    public float spawnTimeMin = 0.5f;
    // 최대 소환 시간
    public float spawnTimeMax = 3f;

    // 총알이 쫓아야 할 타겟(플레이어)
    private Transform target;
    // 소환 시간
    private float spawnTime;
    // 최근 생성 시점에서 지난 시간
    private float timeAfterSpawn;

    private void Start()
    {
        // 최근 생성 이후의 시간을 0으로 리셋
        timeAfterSpawn = 0f;
        // 소환 시간을 최소 소환 시간과 최대 소환 시간 사이의 랜덤한 값으로 지정
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        // 현재 씬에서 PlayerController 컴포넌트를 갖고 있는 게임 오브젝트를 target으로 지정한다.
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        // 시간 누적
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서 누적된 시간이 spawnTime보다 크거나 같다면 실행
        if(timeAfterSpawn >= spawnTime)
        {
            // 다시 최근 생성 이후의 시간을 0으로 리셋
            timeAfterSpawn = 0f;

            // 총알 소환
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 총알이 바라볼 정면으로 방향은 플레이어의 방향으로 설정
            bullet.transform.LookAt(target);

            // 다시 소환 시간을 설정해준다.
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }
}
