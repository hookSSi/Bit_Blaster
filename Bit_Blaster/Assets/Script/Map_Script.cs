using UnityEngine;
using System.Collections;

public class Map_Script: MonoBehaviour {

    public float X; // X 축 반지름
    public float Y; // Y 축 반지름

    public GameObject[] m_WallArray;
    public Camera m_MainCamera;

    void Awake()
    {
        m_MainCamera.orthographicSize = Y;
        m_WallArray[0].transform.position = new Vector2(0, Y-0.5f);
        m_WallArray[0].transform.localScale = new Vector3(X / 6, 1, 1);
        m_WallArray[1].transform.position = new Vector2(0, -Y+0.5f);
        m_WallArray[1].transform.localScale = new Vector3(X / 6, 1, 1);
        m_WallArray[2].transform.position = new Vector2(-X+0.5f, 0);
        m_WallArray[2].transform.localScale = new Vector3(Y / 6, 1, 1);
        m_WallArray[3].transform.position = new Vector2(X-0.5f, 0);
        m_WallArray[3].transform.localScale = new Vector3(Y / 6, 1, 1);
    }
	
	void Update ()
    {
        DrawOutLine();
    }

    void DrawOutLine()
    {
        Debug.DrawLine(new Vector2(X, Y), new Vector2(-X, Y));
        Debug.DrawLine(new Vector2(X, -Y), new Vector2(-X, -Y));
        Debug.DrawLine(new Vector2(X, Y), new Vector2(X, -Y));
        Debug.DrawLine(new Vector2(-X, Y), new Vector2(-X, -Y));
    }
}
