using UnityEngine;
using System.Collections;

public class moveCharacter : FlightObject_Script
{
	public float m_CharacterSpeed;

	GameObject m_FirePoint;

	public GameObject[] m_Weapon;

	GameObject m_MissileTemp;

	public float m_AttackSpeed = 0.2f;

	bool canAttack = true;

	float dirX;

	float dirY;

	float angle;

	private int itemIndex;

	Vector2 movement;

	void Start()
	{
		m_FirePoint = transform.FindChild("m_FirePosition").gameObject;
		itemIndex = 0;
	}


	void Update()
	{
		Move();

		AttackCheck();

	}

	protected override void Move()
	{
		dirX = Input.GetAxis("Horizontal");

		dirY = Input.GetAxis("Vertical");

		angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;

		movement = new Vector2(dirX, dirY);

		if (dirX == 0 && dirY == 0)
		{

		}

		else
		{
			gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);
		}

		GetComponent<Rigidbody2D>().velocity = movement * m_CharacterSpeed;

	}

	void AttackCheck()
	{

		if (/*Input.GetButtonDown("Fire1") && */canAttack == true)
		{
			StartCoroutine("Fire");
		}
	}

	IEnumerator Fire()
	{
		canAttack = false;

		//m_MissileTemp = Instantiate(m_Weapon[itemIndex], new Vector2(m_FirePoint.transform.position.x, m_FirePoint.transform.position.y), Quaternion.Euler(0, 0, -angle)) as GameObject;
		//this.GetComponent<ShootBullet>().Shoot();
		m_Weapon[itemIndex].GetComponent<PlayerBullet>().SetEulerAngleZ(this.transform.eulerAngles.z);
		Instantiate(m_Weapon[itemIndex], new Vector2(m_FirePoint.transform.position.x, m_FirePoint.transform.position.y), Quaternion.Euler(0, 0, -angle));

		Debug.Log(m_Weapon[itemIndex].GetComponent<PlayerBullet>().GetBulletDelay());
		yield return new WaitForSeconds(m_Weapon[itemIndex].GetComponent<PlayerBullet>().GetBulletDelay());

		canAttack = true;
	}

	public float GetEulerAngleZ()
	{
		return this.transform.eulerAngles.z;
	}

}