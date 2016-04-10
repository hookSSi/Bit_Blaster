using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public Camera m_Camera;
    private Color m_Color;

    void Start()
    {
        GenerateRandomColor();
        InvokeRepeating("Sparkle", 0.1f, 10f);
    }

    void FixedUpdate()
    {
        Sparkle();
    }

    void Sparkle()
    {
        m_Camera.backgroundColor = Color.Lerp(m_Camera.backgroundColor, m_Color, 0.1f);
        GenerateRandomColor();
    }

    void GenerateRandomColor()
    {
        m_Color.r = Random.Range(0.5f, 1f);
        m_Color.g = Random.Range(0f, 1f);
        m_Color.b = Random.Range(0f, 1f);
        m_Color.a = Random.Range(0.8f, 1f);
    }
}
