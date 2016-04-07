using UnityEngine;
using System.Collections;

public class EnemyBlue_script : EnemyRed_script {

    private FlightObject_Script bullet;

    void Start()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_Velocity = 2f;
        m_HealthPoint = 1;
        m_Score = 100;
        bullet = m_Bullet.GetComponent<Bullet_Script>();
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
           Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.SetAngle(this.transform.eulerAngles.z + 30 * i);
        }

        Destroy(this.gameObject);
    }
}
