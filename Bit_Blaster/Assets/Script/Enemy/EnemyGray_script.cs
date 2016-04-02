using UnityEngine;
using System.Collections;

public class EnemyGray_script : Enemy_script
{

	void Awake()
	{
		m_Rigid = GetComponent<Rigidbody2D>();
		SetDirection(Vector2.down);
		m_Velocity = 1f;
		m_HealthPoint = 10;
		m_FireRate = 2.5f;
		m_Score = 500;
		m_DropChance = 10;
		InvokeRepeating("FireBullet", 1f, m_FireRate);
	}

	protected override void FireBullet() // 공격 처리
	{
		GameObject tmpPlayer = GameObject.FindWithTag("Player");
		float tmpAngle;

		tmpAngle = Mathf.Atan2(this.transform.position.x - tmpPlayer.transform.position.x, this.transform.position.y - tmpPlayer.transform.position.y);
		m_Bullet.GetComponent<GrayEnemyBullet>().SetEulerAngleZ(tmpAngle);
		Instantiate(m_Bullet, m_FirePosition.position, Quaternion.Euler(new Vector3(0, 0, this.transform.eulerAngles.z)));
	}
}
