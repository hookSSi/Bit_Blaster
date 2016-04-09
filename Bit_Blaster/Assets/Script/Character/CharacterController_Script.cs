﻿using UnityEngine;
using System.Collections;

public class CharacterController_Script : FlightObject_Script {

    
    
    public GameObject m_Bullet; // 총알
    public float m_FireRate = 0.2f; // 공격 딜레이
    public Transform m_FirePosition; // 발사 위치
    public GameObject m_FireSound; // 발사 소리
    public GameObject m_MovingSound; // 이동 소리
    public GameObject m_DestroyedSound; // 죽는 소리

    private bool m_IsAlive = true;  // 살아있니?
    float dirX = 0;
    float dirY = 1;
    
    

	void Start () 
    {
        m_Velocity = 3.5f;
        InvokeRepeating("FireBullet", 0.1f,m_FireRate);
	}
	
    void Update()
    {
        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
        }
    }

	void FixedUpdate () 
    {
	    if(!m_IsAlive)
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOver");
        }
        else
        {
            Move();
        }
	}

    protected virtual void FireBullet() // 공격 처리
    {
        m_Bullet.GetComponent<Bullet_Script>().SetAngle(this.m_Angle);
        Instantiate(m_Bullet, m_FirePosition.position, Quaternion.Euler(new Vector3(0, 0, this.transform.eulerAngles.z)));
    }

    protected override void Move() // 이동 처리
    {
        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            SetDirection(new Vector2(dirX, dirY));
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) // 충돌 처리
    {
        if (col.gameObject.tag == "Item")
        {
            m_Bullet = col.GetComponent<MoveItem>().m_ItemArray[col.GetComponent<MoveItem>().GetItemIndex()];
            m_FireRate = m_Bullet.GetComponent<Bullet_Script>().GetFireRate();
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
        {
            Instantiate(m_DestroyedSound);
            m_IsAlive = false;
        }    
    }

    /* Get,Set의 구역 */

    public void SetVelocity(float p_Velocity)
    {
        m_Velocity = p_Velocity;
    }

    public void SetBullet(GameObject p_Bullet)
    {
        m_Bullet = p_Bullet;
    }
}