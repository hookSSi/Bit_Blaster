using UnityEngine;
using System.Collections;

public class MoveItem : FlightObject_Script
{
	private Transform m_target;
	private int itemNumber = Random.Range(0, 2);

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();
	}

	protected override void Move()
	{
		if (GameObject.FindWithTag("Player") != null)
		{
			m_target = GameObject.FindGameObjectWithTag("Player").transform;
			Vector2 vec = m_target.position - transform.position;
			SetDirection(vec.normalized);
			m_Rigid.velocity = m_Direction * m_Velocity;
		}
	}

	public int GetItemNumber()
	{
		return itemNumber;
	}
}
