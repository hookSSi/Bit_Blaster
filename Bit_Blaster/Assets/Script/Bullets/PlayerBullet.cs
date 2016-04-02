using UnityEngine;
using System.Collections;

public class PlayerBullet : FlightObject_Script
{
	public float bulletAngle;
	public float bulletDelay;

	private float speed;
	

	public GameObject target;

	// Use this for initialization
	void Start()
	{
		speed = 0.2f;
		bulletDelay = 0.2f;
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
		/*if (target.GetComponent<DetectRange>().sprite == null)
			this.transform.position += new Vector3(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * speed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * speed, 0);

		else
		{
			Transform tmp = target.GetComponent<DetectRange>().sprite.transform;

			if (Mathf.Abs(Mathf.Atan2(tmp.TransformPoint(Vector3.zero).y - this.transform.position.y, tmp.TransformPoint(Vector3.zero).x - this.transform.position.x) * Mathf.Rad2Deg - this.transform.eulerAngles.z) < 22.5f)
			{
				bulletAngle = Mathf.Atan2(tmp.TransformPoint(Vector3.zero).y - this.transform.position.y, tmp.TransformPoint(Vector3.zero).x - this.transform.position.x) * Mathf.Rad2Deg;
				this.transform.position += new Vector3(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * speed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * speed, 0);
				Debug.Log(bulletAngle);
			}

			else
			{
				this.transform.position += new Vector3(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * speed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * speed, 0);
				//Debug.Log(Mathf.Abs(Mathf.Atan2(target.transform.TransformPoint(Vector3.zero).y - this.transform.position.y, target.transform.TransformPoint(Vector3.zero).x - this.transform.position.x)) * Mathf.Rad2Deg);
			}

		}*/
		//Debug.Log(Mathf.Atan2(target.transform.position.y - this.transform.position.y, target.transform.position.x - this.transform.position.x) * Mathf.Deg2Rad);
	}

	public void SetEulerAngleZ(float nAngle)
	{
		this.bulletAngle = nAngle;
	}

	public float GetBulletDelay()
	{
		return this.bulletDelay;
	}

	protected void SetTarget(GameObject nTarget)
	{
		//Debug.Log(nTarget);
		this.target = nTarget;
		//Debug.Log(target);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") Destroy(gameObject);
	}
}
