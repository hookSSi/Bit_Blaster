﻿using UnityEngine;
using System.Collections;

public class FlightObject_Script : MonoBehaviour {

    /* 이동 관련 변수 */
    protected Rigidbody2D m_Rigid; // rigidbody
    protected Vector2 m_Direction = Vector2.down; // 방향
    protected float m_MaxVelocity = 1f; // 최대 속도
    protected float m_ForceScale = 100f; // 힘크기

    void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>(); // rigidbody
        SetDirection(Vector2.down); // 방향
        m_MaxVelocity = 1f; // 최대 속도
        m_ForceScale = 100f; // 힘크기
    }

    protected virtual void Move()
    {
        m_Rigid.AddForce(m_Direction * m_ForceScale, ForceMode2D.Impulse);

        /* 속도 제한 */
        if (Mathf.Abs(m_Rigid.velocity.x) > m_MaxVelocity)
            m_Rigid.velocity = new Vector2(NormalizeValue(m_Rigid.velocity.x) * m_MaxVelocity, m_Rigid.velocity.y);
        if (Mathf.Abs(m_Rigid.velocity.y) > m_MaxVelocity)
            m_Rigid.velocity = new Vector2(m_Rigid.velocity.x, NormalizeValue(m_Rigid.velocity.y) * m_MaxVelocity);
    }

    int NormalizeValue(float a)
    {
        return (int)(a / Mathf.Abs(a));
    }

    /* Get,Set */

    public float GetMaxVelocity()
    {
        return m_MaxVelocity;
    }

    public float GetForceScale()
    {
        return m_ForceScale;
    }

    public Vector2 GetDirection()
    {
        return m_Direction;
    }

    public void SetDirection(Vector2 p_Direction)
    {
        m_Direction = p_Direction;
        transform.eulerAngles = new Vector3(0, 0, Vector2.Dot(p_Direction,new Vector2(0,1)));
    }

    public void SetMaxVelocity(float p_MaxVelocity)
    {
        m_MaxVelocity = p_MaxVelocity;
    }

    public void SetForceScale(float p_ForceScale)
    {
        m_ForceScale = p_ForceScale;
    }
}
