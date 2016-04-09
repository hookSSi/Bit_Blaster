using UnityEngine;
using System.Collections;

public class SpreadBullet : Bullet_Script
{
	public GameObject m_SubBullet;

    private Bullet_Script SubBullet;

	// Use this for initialization
	void Start()
	{
        SubBullet = m_SubBullet.GetComponent<Bullet_Script>();
		m_Velocity = 10f;
		m_FireRate = 0.5f;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();
		DestroyOutOfMap();
	}

	public float GetBulletDelay()
	{
		return m_FireRate;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
            Bullet_Script ForSpawn;

			for (int i = 0; i <= 36; i++)
			{
                ForSpawn = Instantiate(SubBullet, transform.position, Quaternion.identity) as Bullet_Script;
                ForSpawn.SetAngle(i * 10);
			}
			Destroy(gameObject);
		}
	}
}
