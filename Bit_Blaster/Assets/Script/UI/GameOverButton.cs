using UnityEngine;
using System.Collections;

public class GameOverButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel("title");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    public void loadTitle()
    {
        Application.LoadLevel("title");
    }

    public void exit()
    {
        Application.Quit();
    }
}
