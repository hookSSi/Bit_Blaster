using UnityEngine;
using System.Collections;

public class Map_Script: MonoBehaviour {

    public float X; // X 축 반지름
    public float Y; // Y 축 반지름

    void Awake()
    {
       
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
