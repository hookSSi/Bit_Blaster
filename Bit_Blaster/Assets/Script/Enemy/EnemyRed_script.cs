using UnityEngine;
using System.Collections;

public class EnemyRed_script : Enemy_script {

    protected Transform m_target;
    protected int x; // 플레이어 없을 때 향해야할 x
    protected int y; // 플레이어 없을 때 향해야할 y

    void Start()
    {
        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        m_Rigid = GetComponent<Rigidbody2D>();
        m_Velocity = 2f;
        m_HealthPoint = 1;
        m_Score = 100;    
    }

    protected override void Move()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            m_target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 vec = m_target.position- transform.position;
            SetDirection(vec.normalized);
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
        else
        {
            Vector2 vec = new Vector2(x, y);
            SetDirection(vec.normalized);
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
    }
}
