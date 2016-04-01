using UnityEngine;
using System.Collections;

public class MoveBullet1 : MonoBehaviour
{
	public float angle;
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

	void Move()
	{
		this.transform.position += new Vector3(-Mathf.Sin(angle * Mathf.Deg2Rad) * speed, Mathf.Cos(angle * Mathf.Deg2Rad) * speed, 0);
	}

	public void SetAngle(float nAngle)
	{
		this.angle = nAngle;
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
