using UnityEngine;
using System.Collections;

public class Bullet : FlightObject_Script
{
    public float m_AttackDelay;

    public float m_BulletSpeed;

    public float m_Damage;

    Vector2 m_InstantiatedPosition;

    void Start()
    {
        Vector2 m_InstantiatedPosition = gameObject.transform.position;
    }

	void Update ()
    {
        Move();

        KillBulletCheck();
	}

    void Move()
    {
        gameObject.transform.Translate(Vector2.up * (m_BulletSpeed / 100));

    }

    void KillBulletCheck()
    {
        if (Vector2.Distance(m_InstantiatedPosition, transform.position) >= 5)
        {
            Destroy(gameObject);
        }
    }
}
