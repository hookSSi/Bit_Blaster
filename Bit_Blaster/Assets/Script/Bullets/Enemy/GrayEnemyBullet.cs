using UnityEngine;
using System.Collections;

public class GrayEnemyBullet : Bullet_Script
{

	// Use this for initialization	
	void Start()
	{
        m_Velocity = 5f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
	}

}
