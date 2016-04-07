using UnityEngine;
using System.Collections;

public class Bullet_Script : FlightObject_Script {

    protected float m_BulletDelay; // 총알 딜레이

    void Awake ()
    {
        m_Rigid = GetComponent<Rigidbody2D>(); // rigidbody
        SetDirection(Vector2.down); // 방향
        m_Velocity = 0.1f; // 속도
        m_BulletDelay = 0.2f;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
        DestroyOutOfMap();
    }

    protected override void Move()
    {
        transform.position += new Vector3(-Mathf.Sin(m_Angle * Mathf.Deg2Rad) * m_Velocity, Mathf.Cos(m_Angle * Mathf.Deg2Rad) * m_Velocity, 0);
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") Destroy(gameObject);
    }
}
