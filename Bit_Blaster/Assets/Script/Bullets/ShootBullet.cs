using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject FirePosition;
	private int pattern;

	// Use this for initialization
	void Start ()
	{
		pattern = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Shoot(float nCharacterAngle)
	{
		Bullet.GetComponent<MoveBullet1>().SetAngle(nCharacterAngle);

		/*if(this.pattern == 1)
		{
			for(int i = 0; i < 36; i++)
			{

			}
		}*/

		if(this.pattern == 1)
			Instantiate(Bullet, new Vector2(FirePosition.transform.position.x, FirePosition.transform.position.y), Quaternion.identity);
	}
}
