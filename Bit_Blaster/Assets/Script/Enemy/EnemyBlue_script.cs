using UnityEngine;
using System.Collections;

public class EnemyBlue_script : EnemyRed_script {


    void Start()
    {
        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        m_Rigid = GetComponent<Rigidbody2D>();
        m_Velocity = 2f;
        m_HealthPoint = 1;
        m_Score = 100;
    }

    void Update()
    {
        if (m_IsAlive == false)
        {
            Explode();
            Destroy(this.gameObject);
        }
        DestroyOutOfMap();
    }

    protected virtual void Explode()
    {
        Bullet_Script ForSpawn;

        for (int i = 0; i <= 12; i++)
        {
           ForSpawn = Instantiate(Bullet, transform.position, Quaternion.identity) as Bullet_Script;
           ForSpawn.SetAngle(30 * i);
        }
    }
}
