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

    Vector2 m_TempMovement;

    public int itemIndex;

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
            movement = m_TempMovement;
        }

		else
		{
            m_TempMovement = movement;

			gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);
		}

        //GetComponent<Rigidbody2D>().velocity = movement * m_CharacterSpeed;
        gameObject.transform.Translate(Vector2.up * m_CharacterSpeed * Time.timeScale * Time.deltaTime );
        //Debug.Log(Time.deltaTime);
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
		if (itemIndex == 0) m_Weapon[itemIndex].GetComponent<PlayerBullet>().SetEulerAngleZ(this.transform.eulerAngles.z);
		else if(itemIndex == 1) m_Weapon[itemIndex].GetComponent<BigRedBullet>().SetEulerAngleZ(this.transform.eulerAngles.z);
		Instantiate(m_Weapon[itemIndex], new Vector2(m_FirePoint.transform.position.x, m_FirePoint.transform.position.y), Quaternion.Euler(0, 0, -angle));

		//Debug.Log(m_Weapon[itemIndex].GetComponent<PlayerBullet>().GetBulletDelay());
		yield return new WaitForSeconds((0.2f * 50) * (1/Time.timeScale) * Time.deltaTime);

		canAttack = true;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            itemIndex = col.GetComponent<MoveItem>().GetItemNumber();
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);

            Application.LoadLevel("GameOver");
        }


    }

	public float GetEulerAngleZ()
	{
		return this.transform.eulerAngles.z;
	}

}