using UnityEngine;
using System.Collections;

public class GrayEnemyBullet : FlightObject_Script
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
		this.transform.position += new Vector3(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * speed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * speed, 0);
	}

	public void SetEulerAngleZ(float nAngle)
	{
		GameObject tmpPlayer = GameObject.FindWithTag("Player");
		this.bulletAngle = nAngle;
		bulletAngle = Mathf.Atan2(tmpPlayer.transform.position.y - this.transform.position.y, tmpPlayer.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
	}
}
