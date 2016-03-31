using UnityEngine;
using System.Collections;

public class Enemy_script : FlightObject_Script {

    protected bool m_IsAlive = true;
    private int m_HealthPoint = 3; // 체력
    private float m_FireRate = 1; // 발사 주기

    public GameObject m_Bullet; // 총알
    public Transform m_FirePosition; // 발사 위치
    public AudioClip m_FireSound; // 발사 소리
    public AudioClip m_MovingSound; // 이동 소리
    public AudioClip m_DestroyedSound; // 죽는 소리

    void Awake ()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        InvokeRepeating("FireBullet", 1f, m_FireRate);
    }
	
    void Update()
    {
        if (m_IsAlive == false)
            Destroy(this.gameObject);
    }

	void FixedUpdate ()
    {
        if(m_IsAlive)
        {
            Move();    
        }
	}

    void OnTriggerEnter2D(Collider2D p_other) // 충돌 처리
    {
        if (p_other.tag == "Player")
        {
            m_HealthPoint--;
            if (m_HealthPoint == 0)
                m_IsAlive = false;
        }
    }

    protected virtual void FireBullet() // 공격 처리
    {
        Instantiate(m_Bullet, m_FirePosition.position, Quaternion.identity);
    }

    public void SetHelthPoint(int p_HealthPoint)
    {
        m_HealthPoint = p_HealthPoint;
    }

    public void SetFireRate(float p_FireRate)
    {
        m_FireRate = p_FireRate;
    }
}
