using UnityEngine;
using System.Collections;

public class FlightObject_Script : MonoBehaviour {

    /* 이동 관련 변수 */
    protected Rigidbody2D m_Rigid; // rigidbody
    protected Vector2 m_Direction; // 방향
    protected float m_MaxVelocity; // 최대 속도
    protected float m_ForceScale; // 힘크기

    void Awake ()
    {
        m_MaxVelocity = 1f; 
        m_Direction = Vector2.down; 
        m_ForceScale = 1f; 
        m_Rigid = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate ()
    {
        Move();
    }

    void Move()
    {
        m_Rigid.AddForce(m_Direction * m_ForceScale,ForceMode2D.Impulse);

        /* 속도 제한 */
        if(Mathf.Abs(m_Rigid.velocity.x) > m_MaxVelocity)
            m_Rigid.velocity = new Vector2(NormalizeValue(m_Rigid.velocity.x) * m_MaxVelocity, m_Rigid.velocity.y);
        if(Mathf.Abs(m_Rigid.velocity.y) > m_MaxVelocity)
            m_Rigid.velocity = new Vector2(m_Rigid.velocity.x, NormalizeValue(m_Rigid.velocity.y) * m_MaxVelocity);
    }

    int NormalizeValue(float a)
    {
        return (int)(a / Mathf.Abs(a));
    }
}
