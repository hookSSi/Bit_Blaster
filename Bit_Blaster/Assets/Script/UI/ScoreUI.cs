using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{

    bool m_TimeCheck = true;

    float m_ScoreEarningPeriod = 2;

    int Score = 0;

    GameObject m_PointTaxt;

    bool Pause = true;

    void Start ()
    {
        m_PointTaxt = GameObject.Find("Point");
	}
	
	void Update ()
    {
        EarnScoreCheck();

        PauseGame();
    }

    void EarnScoreCheck()
    {
        if (m_TimeCheck == true)
        {
            StartCoroutine("EarnScore");
        }

    }

    IEnumerator EarnScore()
    {
        m_TimeCheck = false;

        Score += 10;

        m_PointTaxt.GetComponent<Text>().text = System.Convert.ToString(Score);

        yield return new WaitForSeconds(m_ScoreEarningPeriod);

        m_TimeCheck = true;
    }

    void PauseGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Pause == true)
            {
                Time.timeScale = 0;

                Pause = false;
            }
            else
            {
                Time.timeScale = 1;

                Pause = true;
            }
        }
    }
}
