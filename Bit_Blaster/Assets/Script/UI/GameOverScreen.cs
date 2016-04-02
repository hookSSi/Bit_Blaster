using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    GameObject point;

    GameObject pointShow;

    void Start ()
    {
        point = GameObject.Find("ScoreStorage");

        pointShow = GameObject.Find("Score");

        SroceShow();
    }
	
	void Update ()
    {
	    
	}

    void SroceShow()
    {
        //pointShow.GetComponent<Text>().text = "아차 점수는 " + point.GetComponent<ScoreStorage>().Score + "점";
    }
}
