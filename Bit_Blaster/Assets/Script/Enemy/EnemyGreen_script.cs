using UnityEngine;
using System.Collections;

public class EnemyGreen_script : Enemy_script
{
    void Start()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_MaxVelocity = 1f;
        m_ForceScale = 100f;
        m_HealthPoint = 3;
        m_FireRate = 1;
    }

    void Update()
    {
        if (m_IsAlive == false)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (m_IsAlive)
        {
            Move();
        }
    }
}
