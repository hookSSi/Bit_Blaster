﻿using UnityEngine;
using System.Collections;

public class FlightObject_Script : MonoBehaviour {

    /* 이동 관련 변수 */
    protected Rigidbody2D m_Rigid; // rigidbody
    protected float m_Velocity; // 속도
    protected Vector2 m_Direction; // 방향
    protected float m_Angle; //각도
    protected SpriteRenderer m_SpriteRenderer; // 스프라이트 렌더러

    public Material m_BasicMaterial; // 기본 메터리얼
    public Material m_HitMaterial; // 피격 효과 메터리얼

    void Awake()
    {
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.up);
        m_Velocity = 1f;
        m_Angle = 0;
    }

    protected virtual void Move()
    {
        m_Rigid.velocity = m_Direction * m_Velocity;
    }

    int NormalizeValue(float a)
    {
        return (int)(a / Mathf.Abs(a));
    }

    public void DestroyOutOfMap()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height+10 || screenPosition.y < -10 || screenPosition.x > Screen.width+10 || screenPosition.x < -10)
        {
            Destroy(gameObject);
        }
    }

    /* Get,Set */

    public float GetMaxVelocity()
    {
        return m_Velocity;
    }


    public Vector2 GetDirection()
    {
        return m_Direction;
    }

    public virtual void SetDirection(Vector2 p_Direction)
    {
        m_Direction = p_Direction;
        transform.eulerAngles = new Vector3(0,0,-1 * Mathf.Atan2(p_Direction.x, p_Direction.y) * Mathf.Rad2Deg);
    }

    public void SetVelocity(float p_Velocity)
    {
        this.m_Velocity = p_Velocity;
    }

    public void SetAngle(float p_Angle)
    {
        this.m_Angle = p_Angle;
        transform.eulerAngles = new Vector3(0, 0, m_Angle);
        m_Direction = new Vector3(-Mathf.Sin(p_Angle * Mathf.Deg2Rad), Mathf.Cos(p_Angle * Mathf.Deg2Rad));
    }

    public float GetAngle()
    {
        return this.m_Angle;
    }
}
