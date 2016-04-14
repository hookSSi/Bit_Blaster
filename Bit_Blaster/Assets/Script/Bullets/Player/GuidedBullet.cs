using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuidedBullet : Bullet_Script
{
	public Transform m_Target;

	// Use this for initialization
	void Start()
	{
		m_Velocity = 10f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
	}

	/*public override void SetDirection(Vector2 p_Direction)
	{
		m_Direction = p_Direction;
		//transform.eulerAngles = new Vector3(0, 0, 180 - 1 * Mathf.Atan2(p_Direction.y, p_Direction.x) * Mathf.Rad2Deg);
	}*/

	protected override void Move()
	{
		if (m_Target != null)
		{
			Vector2 vec = m_Target.position - transform.position;
			SetDirection(vec.normalized);
		}

		m_Rigid.velocity = m_Direction * m_Velocity;

	}

	protected override void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") Destroy(gameObject);
	}

	public void SetTarget(float x, float y, Transform firePosition)
	{
		List<Transform> enemyArray = new List<Transform>();

		foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			if ((tmp.transform.position.x - firePosition.position.x) >= 0 && (tmp.transform.position.y - firePosition.position.y) >= 0)
				if (0 <= x && 0 <= y) enemyArray.Add(tmp.transform);

			if ((tmp.transform.position.x - firePosition.position.x) >= 0 && (tmp.transform.position.y - firePosition.position.y) <= 0)
				if (0 <= x && y <= 0) enemyArray.Add(tmp.transform);

			if ((tmp.transform.position.x - firePosition.position.x) <= 0 && (tmp.transform.position.y - firePosition.position.y) >= 0)
				if (x <= 0 && 0 <= y) enemyArray.Add(tmp.transform);

			if ((tmp.transform.position.x - firePosition.position.x) <= 0 && (tmp.transform.position.y - firePosition.position.y) <= 0)
				if (x <= 0 && y <= 0) enemyArray.Add(tmp.transform);
		}

		if (enemyArray.Count != 0) m_Target = enemyArray[Random.Range(0, enemyArray.Count)];
	}
}
