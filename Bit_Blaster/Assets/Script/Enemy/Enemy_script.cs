﻿using UnityEngine;
using System.Collections;

public class Enemy_script : FlightObject_Script {

    protected bool m_IsAlive = true; // 살아있니?
    protected int m_HealthPoint; // 체력
    protected float m_FireRate; // 발사 주기
    protected int m_Score; // 플레이어가 얻는 점수
    protected int m_DropChance; // 드랍 확률 조절
    protected Bullet_Script Bullet; // 총알 생성용
    protected bool m_IsHit = false; // 피격 당함?
    protected float m_Time = 0; // 시간

    public GameObject[] m_Item; // 드랍 아이템
    public GameObject m_Bullet; // 총알
    public Transform m_FirePosition; // 발사 위치
    public GameObject m_FireSound; // 발사 소리
   // public GameObject m_MovingSound; // 이동 소리
    public GameObject m_DestroyedSound; // 죽는 소리

    

    void Awake()
    {
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_Rigid = GetComponent<Rigidbody2D>();
        Bullet = m_Bullet.GetComponent<Bullet_Script>();
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.zero);
        m_Angle = 0;
        m_Velocity = 1f;
        m_HealthPoint = 3;
        m_FireRate = 1;
        m_Score = 100;
        m_DropChance = 1;
    }
	
    void Update()
    {
        if (m_IsAlive == false)
        {
            DropItem();
            Destroy(this.gameObject);
        }
        DestroyOutOfMap();
    }

	void FixedUpdate ()
    {
        if(m_IsAlive)
        {
            Move();    
        }

        /* 나중에 고쳐야 할 코드 - 피격 효과 */
        if(m_IsHit)
            m_Time += Time.deltaTime;
        if (m_Time > 0.5)
        {
            m_Time = 0;
            m_IsHit = !m_IsHit;
            CancelInvoke("Flash");
        }
    }

    protected void OnTriggerEnter2D(Collider2D p_other) // 충돌 처리
    {
        if (p_other.tag == "PlayerBullet") // 총알에 충돌 했을 때
        {
            InvokeRepeating("Flash", 0, 0.1f);
            m_IsHit = true;
            m_HealthPoint--;
            if (m_HealthPoint == 0)
            {
                GameManager.AddScore(m_Score);
                Instantiate(m_DestroyedSound);
                m_IsAlive = false;
            }
        }

        else if(p_other.tag == "Player") // 플레이어와 충돌 했을 때
        {
            m_IsAlive = false;
        }
    }

    protected virtual void FireBullet() // 공격 처리
    {
        Instantiate(m_Bullet, m_FirePosition.position, Quaternion.identity);
    }

    protected virtual void DropItem()
    {
        int value1 = Random.Range(0, m_DropChance + m_Item.Length);
        int value2 = Random.Range(0, m_Item.Length);

        if (value1 == value2 && m_Item.Length > 0)
            Instantiate(m_Item[value2],transform.position, Quaternion.identity);
    }

    protected virtual void Flash() // 피격효과
    {
        if (Mathf.Sin(Mathf.PI * 8 * m_Time) > 0)
            m_SpriteRenderer.material = m_HitMaterial;
        else
            m_SpriteRenderer.material = m_BasicMaterial;
    }

    /* Get,Set */

    public void SetHelthPoint(int p_HealthPoint)
    {
        m_HealthPoint = p_HealthPoint;
    }

    public void SetFireRate(float p_FireRate)
    {
        m_FireRate = p_FireRate;
    }

    public int GetHealthPoint()
    {
        return m_HealthPoint;
    }
}
