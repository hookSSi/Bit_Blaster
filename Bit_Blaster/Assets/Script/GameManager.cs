using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public float X; // X 축 반지름
    public float Y; // Y 축 반지름

    public GameObject[] m_WallArray; // 벽의 배열
    public Camera m_MainCamera; // 메인 카메라

    public Text m_ScoreText; // 게임 중 점수 텍스트 UI
    public Text m_HighScoreText; // 게임 최고 점수 텍스트 UI
    public GameObject m_PauseMenu; // 일시정지 메뉴

    private int m_HighScore;
    private static int m_Score;
    private bool pause = false;

    void Start()
    {
        SetGame();
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
       
        if(Time.timeScale == 1)
        {
            if (Input.GetButtonDown("360_P1_StartButton"))
            {
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetButtonDown("360_P1_StartButton"))
            {
                Time.timeScale = 1;
            }
        }
    }

    void FixedUpdate()
    {
        ScoreUpdate();
    } 

    void SetGame()
    {
        //UnityEngine.Cursor.visible = false;
        m_MainCamera.orthographicSize = Y;
        m_WallArray[0].transform.position = new Vector2(0, Y - 0.5f);
        m_WallArray[0].transform.localScale = new Vector3(X / 6, 1, 1);
        m_WallArray[1].transform.position = new Vector2(0, -Y + 0.5f);
        m_WallArray[1].transform.localScale = new Vector3(X / 6, 1, 1);
        m_WallArray[2].transform.position = new Vector2(-X + 0.5f, 0);
        m_WallArray[2].transform.localScale = new Vector3(Y / 6, 1, 1);
        m_WallArray[3].transform.position = new Vector2(X - 0.5f, 0);
        m_WallArray[3].transform.localScale = new Vector3(Y / 6, 1, 1);

        m_Score = 0;  
    }

    /* 스코어 관련 함수들 */

    void ScoreUpdate()
    {
        m_Score += Random.Range(1, 3);
        m_ScoreText.text = "Score : " + m_Score;
        SaveData();
        m_HighScore = PlayerPrefs.GetInt("HighScore");
        m_HighScoreText.text = "High Score : " + m_HighScore;
    }

    public static void AddScore(int p_Score)
    {
        m_Score += p_Score;
    }

    /* UI관리 관련 함수들 */

    public void Pause()
    {
        pause = !pause;

        if (pause == false)
        {
            m_PauseMenu.SetActive(pause);
            Time.timeScale = 1;
        }

        else
        {
            m_PauseMenu.SetActive(pause);
            Time.timeScale = 0;
        }
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        SaveData();
        SceneManager.LoadScene("GameOver");
    }

    public static void Exit()
    {
        Application.Quit();
    }

    public static void SaveData()
    {
        if (PlayerPrefs.GetInt("HighScore") < m_Score)
        {
            PlayerPrefs.SetInt("HighScore", m_Score);
        }
    }

    public int GetData()
    {
        return m_HighScore;
    }

}
