using UnityEngine;
using System.Collections;

public class Bullet_Script : FlightObject_Script {

    protected float m_FireRate; // 총알 딜레이

    void Start()
    {
        m_Velocity = 10f; // 속도
        m_FireRate = 0.2f;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Move();
        DestroyOutOfMap();
    }

    /*protected override void Move()
    {
        transform.position += new Vector3(-Mathf.Sin(m_Angle * Mathf.Deg2Rad) * m_Velocity, Mathf.Cos(m_Angle * Mathf.Deg2Rad) * m_Velocity, 0);
    }*/

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
