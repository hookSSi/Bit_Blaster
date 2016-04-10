using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleButton : MonoBehaviour
{

    public void loadGame()
    {
        SceneManager.LoadScene("1");
    }

    void Update()
    {
        if (Input.GetButtonDown("360_P1_StartButton") || Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("1");
        }
    }

}
