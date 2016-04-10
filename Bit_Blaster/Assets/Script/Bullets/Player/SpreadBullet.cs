using UnityEngine;
using System.Collections;

public class SpreadBullet : Bullet_Script
{
	public GameObject m_SubBullet;

    private Bullet_Script SubBullet; // 생성용
    
	void Start()
	{
        SubBullet = m_SubBullet.GetComponent<Bullet_Script>();
		m_Velocity = 10f;
		m_FireRate = 0.8f;
	}

	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
        
	}

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
            FlightObject_Script ForSpawn;

            for (int i = 0; i <= 36; i++)
            {
                ForSpawn = Instantiate(SubBullet, transform.position, Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetAngle(i * 10);
            }
			Destroy(gameObject);
		}
	}
}
