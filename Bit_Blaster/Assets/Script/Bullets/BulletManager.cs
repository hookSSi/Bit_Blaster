using UnityEngine;
using System.Collections;

public class ShootBullet : moveCharacter
{
	public GameObject Bullet;
	public GameObject FirePosition;

	private int pattern;
	private int bulletCount;
	private float bulletDelay;

	// Use this for initialization
	void Start ()
	{
		bulletCount = 0;
		pattern = 10;
		bulletDelay = 0.2f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Shoot()
	{
		if ((this.pattern) / 10 == 1)
		{
			for (int i = 0; i < 7; i++)
			{
				//Bullet.GetComponent<MoveBullet1>().SetAngle((GetEulerAngleZ() - 30) + (i * 10));
				Instantiate(Bullet, new Vector2(FirePosition.transform.position.x, FirePosition.transform.position.y), Quaternion.identity);
			}
		}

		else if (this.pattern == 1)
		{
			//Bullet.GetComponent<MoveBullet1>().SetAngle(GetEulerAngleZ());
			Instantiate(Bullet, new Vector2(FirePosition.transform.position.x, FirePosition.transform.position.y), Quaternion.identity);
		}
	}

	public void AddBulletCount()
	{
		this.bulletCount++;

		if (bulletCount >= 10)
		{
			pattern++;
			bulletCount = 0;
		}
	}

	public float GetBulletDelay()
	{
		return this.bulletDelay;
	}
}
