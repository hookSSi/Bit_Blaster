﻿using UnityEngine;
using System.Collections;

public class GrayEnemyBullet : Bullet_Script
{

	public float bulletAngle;
	public float bulletDelay;

	private float speed;

	// Use this for initialization	
	void Start()
	{
		speed = 0.2f;
		bulletDelay = 5f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
	}

	protected override void Move()
	{
		this.transform.position += new Vector3(-Mathf.Sin(bulletAngle) * speed, -Mathf.Cos(bulletAngle) * speed, 0);
	}

	public void SetEulerAngleZ(float nAngle)
	{
		this.bulletAngle = nAngle;
	}
}