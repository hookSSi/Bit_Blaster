using UnityEngine;
using System.Collections;

public class EnemyGray_script : Enemy_script
{

	void Start()
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
        Bullet_Script ForSpawn;
		GameObject tmpPlayer = GameObject.FindWithTag("Player");

        if(tmpPlayer != null)
        {
            ForSpawn = Instantiate(Bullet, m_FirePosition.position, transform.rotation) as Bullet_Script;
            ForSpawn.SetDirection(tmpPlayer.transform.position.normalized);
        }		
	}
}
