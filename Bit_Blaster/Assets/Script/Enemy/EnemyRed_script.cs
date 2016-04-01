using UnityEngine;
using System.Collections;

public class EnemyRed_script : Enemy_script {

    private Transform m_target;

	void Awake ()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_Velocity = 3f;
        m_HealthPoint = 1;
    }

    protected override void Move()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector2 vec = m_target.position - transform.position;
        SetDirection(vec.normalized);
        m_Rigid.velocity = m_Direction * m_Velocity;
    }
}
