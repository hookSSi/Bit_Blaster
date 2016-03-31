using UnityEngine;
using System.Collections;

public class MoveCharacter : FlightObject_Script
{
    public float m_CharacterSpeed;

    GameObject m_FirePoint;

    public GameObject m_Weapon;

    GameObject m_MissileTemp;

    public float m_AttackSpeed = 0.2f;

    bool canAttack = true;

    float angle;

    void Start()
    {
        m_FirePoint = transform.FindChild("m_FirePosition").gameObject;
    }


    void Update()
    {
        Move();

        AttackCheck();

    }

    void Move()
    {
        float dirX = Input.GetAxis("Horizontal");

        float dirY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(dirX, dirY);

     //   Debug.Log("X " + dirX);

      //  Debug.Log("Y " + dirY);

        angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;

        gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);

        GetComponent<Rigidbody2D>().velocity = movement * m_CharacterSpeed;

    }

    void AttackCheck()
    {

        if (Input.GetButtonDown("Fire1") && canAttack == true)
        {
            StartCoroutine("Fire");

            Debug.Log("attack");
        }
    }

    IEnumerator Fire()
    {
        canAttack = false;

        m_MissileTemp = Instantiate(m_Weapon, new Vector2(m_FirePoint.transform.position.x, m_FirePoint.transform.position.y), Quaternion.Euler(0,0,-angle)) as GameObject;

        yield return new WaitForSeconds(m_AttackSpeed);

        canAttack = true;
    }

}