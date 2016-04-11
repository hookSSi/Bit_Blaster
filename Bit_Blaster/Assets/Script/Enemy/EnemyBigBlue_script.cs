using UnityEngine;
using System.Collections;

public class EnemyBigBlue_script : EnemyBlue_script {

    public GameObject m_FlightObject;

    void Start ()
    {

        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        m_Rigid = GetComponent<Rigidbody2D>();
        m_Velocity = 0.8f;
        m_HealthPoint = 5;
        m_Score = 300;
        m_FireRate = 3;

        InvokeRepeating("Explode", 2f, m_FireRate);
    }

    protected override void Explode()
    {
        Bullet_Script ForSpawn1;

        for (int i = 0; i <= 6; i++)
        {
            ForSpawn1 = Instantiate(Bullet, transform.position, Quaternion.identity) as Bullet_Script;
            ForSpawn1.SetAngle(i*60);
        }

        Instantiate(m_FlightObject, transform.position, Quaternion.identity);
    }
}
