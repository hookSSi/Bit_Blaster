using UnityEngine;
using System.Collections;

public class EnemyRed_script : Enemy_script {

    private Transform m_target;
    int x = Random.Range(-10, 10);
    int y = Random.Range(-10, 10);
    void Awake ()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_Velocity = 3f;
        m_HealthPoint = 1;
        m_Score = 100;
    }

    protected override void Move()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            m_target = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 vec = m_target.position - transform.position;
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
