using UnityEngine;
using System.Collections;

public class MoveBullet1 : ShootBullet
{
	public float bulletAngle;
	private float speed;
	private Transform playerTransform;

	// Use this for initialization
	void Start ()
	{
		speed = 0.3f;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();
		CheckPosition();
	}

	protected override void Move()
	{
		this.transform.position += new Vector3(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * speed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * speed, 0);
	}

	public void SetAngle(float nAngle)
	{
		this.bulletAngle = nAngle;
	}
    
	private void CheckPosition()
	{
		if (Mathf.Abs(playerTransform.position.x - this.transform.position.x) > 20
			|| Mathf.Abs(playerTransform.position.y - this.transform.position.y) > 30)
		{
			Destroy(this.gameObject);
		}
	}
    
}
