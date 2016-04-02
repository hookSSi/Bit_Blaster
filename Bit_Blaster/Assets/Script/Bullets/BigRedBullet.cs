using UnityEngine;
using System.Collections;

public class BigRedBullet : FlightObject_Script
{
	public float bulletAngle;
	public float bulletDelay;
	public GameObject subBullet;

	private float speed;

	// Use this for initialization
	void Start()
	{
		speed = 0.2f;
		bulletDelay = 0.5f;
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
		this.bulletAngle = nAngle;
	}

	public float GetBulletDelay()
	{
		return this.bulletDelay;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			for (int i = 0; i < 36; i++)
			{
				subBullet.GetComponent<PlayerBullet>().SetEulerAngleZ(this.transform.eulerAngles.z + (i * 10));
				Instantiate(subBullet, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
			}

			Destroy(gameObject);
		}
	}
}
