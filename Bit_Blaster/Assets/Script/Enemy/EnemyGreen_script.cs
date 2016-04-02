using UnityEngine;
using System.Collections;

public class EnemyGreen_script : Enemy_script
{
    void Awake()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.up);
        m_Velocity = 1.5f;
        m_HealthPoint = 3;
        m_FireRate = 1;
        m_Score = 300;
        InvokeRepeating("FireBullet", 1f, m_FireRate);
    }
}
