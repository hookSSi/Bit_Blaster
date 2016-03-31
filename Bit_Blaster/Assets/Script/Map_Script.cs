using UnityEngine;
using System.Collections;

public class Map_Script: MonoBehaviour {

    public float X; // X 축 반지름
    public float Y; // Y 축 반지름
    public float m_LineThickness = 4f; // 경계선 굵기
    public float m_LineIntensity = 5f; // 경계선 강렬한 정도

    public Color m_StartColor = Color.red; // 시작 경계선 색깔
    public Color m_EndColor = Color.yellow; // 끝 경계선 색깔

    private LineRenderer lineRenderer;

	// Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetColors(m_StartColor, m_EndColor);
        lineRenderer.SetWidth(0.1f, 0.1f);
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

        lineRenderer.SetPosition(0, new Vector2(X, Y));
        lineRenderer.SetPosition(1, new Vector2(-X, Y));
        lineRenderer.SetPosition(2, new Vector2(-X, -Y));
        lineRenderer.SetPosition(3, new Vector2(X, -Y));
        lineRenderer.SetPosition(4, new Vector2(X, Y));
    }
}
