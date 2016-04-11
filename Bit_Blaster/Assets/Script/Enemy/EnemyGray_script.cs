using UnityEngine;
using System.Collections;

public class EnemyGray_script : Enemy_script
{
    protected Transform m_target;
    
    float gap;

	void Start()
	{
		m_Rigid = GetComponent<Rigidbody2D>();
		m_Velocity = 1f;
		m_HealthPoint = 10;
		m_FireRate = 2.5f;
		m_Score = 500;
		m_DropChance = 10;
		InvokeRepeating("FireBullet", 1f, m_FireRate);
        gap = Mathf.Cos(Mathf.Deg2Rad*Random.Range(0, 80));
	}

	protected override void FireBullet() // 공격 처리
	{
        Bullet_Script ForSpawn;
		GameObject tmpPlayer = GameObject.FindWithTag("Player");

        if(tmpPlayer != null)
        {
            ForSpawn = Instantiate(Bullet, m_FirePosition.position, transform.rotation) as Bullet_Script;
            Vector2 vec = tmpPlayer.transform.position - transform.position;
            ForSpawn.SetDirection(vec.normalized);
        }		
	}

    protected override void Move()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Vector2 vec;

            m_target = GameObject.FindGameObjectWithTag("Player").transform;
            vec = m_target.position * gap - transform.position;
            SetDirection(vec.normalized);
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
        else
            base.Move();
    }
}
