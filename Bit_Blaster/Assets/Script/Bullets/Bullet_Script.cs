using UnityEngine;
using System.Collections;

public class Bullet_Script : FlightObject_Script {

    protected float m_FireRate; // 총알 딜레이

    void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.up);
        m_Velocity = 30f;
        m_Angle = 0;
        m_FireRate = 0.2f;
    }
	
	void FixedUpdate()
    {
        Move();
        DestroyOutOfMap();
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") Destroy(gameObject);
    }

    /* Get,Set의 구역 */
    public float GetFireRate()
    {
        return this.m_FireRate;
    }
}
