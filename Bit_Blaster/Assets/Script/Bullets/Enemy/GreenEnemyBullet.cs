using UnityEngine;
using System.Collections;

public class GreenEnemyBullet : Bullet_Script
{
	void Start ()
	{
		m_Velocity = 10f;
		m_FireRate = 5f;
	}

	void FixedUpdate ()
	{
		Move();
		DestroyOutOfMap();
	}
}
