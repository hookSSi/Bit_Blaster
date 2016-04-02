using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour
{

    public void loadGame()
    {
        Application.LoadLevel("1");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel("1");
        }
    }

}
