using UnityEngine;
using System.Collections;

public class MoveBullet1 : MonoBehaviour
{
	public float angle;
	private float speed;

	// Use this for initialization
	void Start ()
	{
		speed = 0.3f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();
	}

	void Move()
	{
		this.transform.position += new Vector3(-Mathf.Sin(angle) * speed, Mathf.Cos(angle) * speed, 0);
	}

	public void SetAngle(float nAngle)
	{
		this.angle = nAngle * Mathf.Deg2Rad;
	}
}
