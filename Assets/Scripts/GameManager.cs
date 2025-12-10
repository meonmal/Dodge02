using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임오버가 되면 활성화할 게임 오버 텍스트
    public GameObject gameOverText;
    // 생존 시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    // 최대 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;

    // 게임오버를 확인하는 변수
    private bool gameOver;
    // 현재 생존 시간
    private float surviveTime;

    private void Start()
    {
        // 게임 오버 상태를 false로 설정
        gameOver = false;
        // 현재 생존 시간도 0으로 맞춰준다.
        surviveTime = 0f;
    }

    private void Update()
    {
        // 게임 오버 상태가 아니면 실행
        if (!gameOver)
        {
            // 현재 생존 시간을 갱신한다.
            surviveTime += Time.deltaTime;
            // 생존 시간의 텍스트를 현재 시간으로 설정
            timeText.text = "Time : " + (int)surviveTime;
        }
        // 게임 오버 상태면 실행
        else
        {
            // R 키를 누르면 실행
            if (Input.GetKey(KeyCode.R))
            {
                // SampleScene을 불러온다.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // 플레이어가 죽으면 실행될 함수
    public void EndGame()
    {
        // 게임 오버 상태를 true로 변경
        gameOver = true;
        // 게임 오버 텍스트를 활성화한다.
        gameOverText.SetActive(true);

        // BestTime키로 설정된 최고 기록을 가져온다.
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 만약 현재 생존 시간이 bestTime보다 높으면 실행
        if(surviveTime > bestTime)
        {
            // 최고 생존 시간을 현재 생존 시간으로 설정
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 생존 시간을 나타낸다.
        recordText.text = "BestTime : " + (int)bestTime;
    }
}
