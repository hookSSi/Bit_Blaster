using UnityEngine;
using System.Collections;

public class GrayEnemyBullet : Bullet_Script
{

	public float bulletAngle;
	public float bulletDelay;

	private float speed;

	// Use this for initialization	
	void Start()
	{
        m_Velocity = 5f;
		speed = 0.2f;
		bulletDelay = 5f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
	}

	public void SetEulerAngleZ(float nAngle)
	{
		this.bulletAngle = nAngle;
	}
}
