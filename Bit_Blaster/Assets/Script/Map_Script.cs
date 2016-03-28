using UnityEngine;
using System.Collections;

public class Map_Script: MonoBehaviour {

    public float X;
    public float Y;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
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
