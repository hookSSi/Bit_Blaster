using UnityEngine;
using System.Collections;

public class ShootBullet : moveCharacter
{
	public GameObject Bullet;
	public GameObject FirePosition;
	private int pattern;
	private float bulletDelay;

	// Use this for initialization
	void Start ()
	{
		pattern = 1;
		bulletDelay = 0.2f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Shoot()
	{
		if (this.pattern == 1)
		{
			for (int i = 0; i < 7; i++)
			{
				Bullet.GetComponent<MoveBullet1>().SetAngle((GetEulerAngleZ() - 30) + (i * 10));
				Instantiate(Bullet, new Vector2(FirePosition.transform.position.x, FirePosition.transform.position.y), Quaternion.identity);
			}
		}

		else if (this.pattern == 1)
		{
			Bullet.GetComponent<MoveBullet1>().SetAngle(GetEulerAngleZ());
			Instantiate(Bullet, new Vector2(FirePosition.transform.position.x, FirePosition.transform.position.y), Quaternion.identity);
		}
	}

	public float GetBulletDelay()
	{
		return this.bulletDelay;
	}
}
