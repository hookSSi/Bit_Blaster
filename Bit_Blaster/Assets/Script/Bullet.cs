using UnityEngine;
using System.Collections;

public class Bullet : FlightObject_Script
{
    public float m_AttackSpeed;

    public float m_BulletSpeed;

    public float m_BulletMaintainTime;

    public float m_Damage;

    Vector2 m_InstantiatePosition;

    void Start()
    {
        Vector2 m_InstantiatePosition = gameObject.transform.position;
    }

	void Update ()
    {
        Move();

        KillBulletCheck();
	}

    protected override void Move()
    {
        gameObject.transform.Translate(Vector2.up * (m_BulletSpeed / 100));
    }

    void KillBulletCheck()
    {
        if (Vector2.Distance(m_InstantiatePosition, transform.position) >= 5)
        {
            Destroy(gameObject);
        }
    }
}
