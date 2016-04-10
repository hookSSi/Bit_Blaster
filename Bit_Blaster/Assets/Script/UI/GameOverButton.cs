using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("360_P1_StartButton"))
        {
            SceneManager.LoadScene("title");
        }

        if (Input.GetButtonDown("360_P1_BButton"))
        {
            Application.Quit();
        }
    }

    public void loadTitle()
    {
        SceneManager.LoadScene("title");
    }

    public void exit()
    {
        Application.Quit();
    }
}
