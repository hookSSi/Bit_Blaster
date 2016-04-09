using UnityEngine;
using System.Collections;

public class EnemyBlue_script : EnemyRed_script {

    void Start()
    {
        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_Velocity = 2f;
        m_HealthPoint = 1;
        m_Score = 100;
    }

    void Update()
    {
        if (m_IsAlive == false)
        {
            Explode();
        }
        DestroyOutOfMap();
    }

    void Explode()
    {
        for (int i = 0; i <= 12; i++)
        {
           m_Bullet.GetComponent<Bullet_Script>().SetAngle(30 * i);
           Instantiate(m_Bullet, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }
}
