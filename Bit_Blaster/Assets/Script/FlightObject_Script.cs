using UnityEngine;
using System.Collections;

public class FlightObject_Script : MonoBehaviour {

    /* 이동 관련 변수 */
    protected Rigidbody2D m_Rigid; // rigidbody
    protected Vector2 m_Direction; // 방향
    protected float m_Velocity; // 최대 속도

    void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>(); // rigidbody
        SetDirection(Vector2.down); // 방향
        m_Velocity = 1f; // 최대 속도
    }

    protected virtual void Move()
    {
        m_Rigid.velocity = m_Direction * m_Velocity;
    }

    int NormalizeValue(float a)
    {
        return (int)(a / Mathf.Abs(a));
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

    public void SetDirection(Vector2 p_Direction)
    {

        m_Direction = p_Direction;
        transform.eulerAngles = new Vector3(0, 0, -1 * Mathf.Atan2(p_Direction.x, p_Direction.y) * Mathf.Rad2Deg); // 이동 방향으로 돌림
    }

    public void SetMaxVelocity(float p_MaxVelocity)
    {
        m_Velocity = p_MaxVelocity;
    }
}
