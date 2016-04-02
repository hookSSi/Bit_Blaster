using UnityEngine;
using System.Collections;

public class EnemyGreen_script : Enemy_script
{
	private FlightObject_Script temp;

	void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.up);
        m_Velocity = 1.5f;
        m_HealthPoint = 3;
        m_FireRate = 2;
        m_Score = 300;
        InvokeRepeating("FireBullet", 1f, m_FireRate);
    }

	protected override void FireBullet() // 공격 처리
	{
		m_Bullet.GetComponent<GreenEnemyBullet>().SetEulerAngleZ(this.gameObject.transform.eulerAngles.z);
		Instantiate(m_Bullet, m_FirePosition.position, Quaternion.Euler(new Vector3(0, 0, this.transform.eulerAngles.z)));
	}
}
