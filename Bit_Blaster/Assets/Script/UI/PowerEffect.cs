﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerEffect : MonoBehaviour {

    public Image m_Image;
    private Color m_Color;
	
	void Start () 
    {
        GenerateRandomColor();
        InvokeRepeating("Sparkle", 0.1f, 1f);
	}
	
    void FixedUpdate()
    {
        Sparkle();
    }

    void Sparkle()
    {
        m_Image.color = Color.Lerp(m_Image.color, m_Color, 1f);
        GenerateRandomColor();       
    }

    void GenerateRandomColor()
    {
        m_Color.r = Random.RandomRange(0.5f, 1f);
        m_Color.g = Random.RandomRange(0f, 1f);
        m_Color.b = Random.RandomRange(0f, 1f);
        m_Color.a = Random.RandomRange(0.8f, 1f);
    }
}
