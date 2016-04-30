using UnityEngine;
using System.Collections;

public class EnemyBigBlue_script : EnemyBlue_script {

   // public GameObject m_FlightObject;
    public GameObject m_BigBullet;

    void Start ()
    {
        Bullet = m_BigBullet.GetComponent<Bullet_Script>();

        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);

        m_Rigid = GetComponent<Rigidbody2D>();
        m_Velocity = 0.8f;
        m_HealthPoint = 5;
        m_Score = 300;
        m_FireRate = 3;

        InvokeRepeating("FireBullet", 2f, m_FireRate);
    }

    protected override void Explode()
    {
        Bullet_Script ForSpawn1;
        Bullet = m_Bullet.GetComponent<Bullet_Script>();

        for (int i = 0; i <= 12; i++)
        {
            ForSpawn1 = Instantiate(Bullet, transform.position, Quaternion.identity) as Bullet_Script;
            ForSpawn1.SetAngle(i*30);
            ForSpawn1.SetVelocity(3f);
        }

        for (int i = 0; i <= 6; i++)
        {
            ForSpawn1 = Instantiate(Bullet, transform.position, Quaternion.identity) as Bullet_Script;
            ForSpawn1.SetAngle(15 + i * 60);
            ForSpawn1.SetVelocity(4f);
        }
    }

    protected override void FireBullet() // 공격 처리
    {
        Bullet_Script ForSpawn;
        GameObject tmpPlayer = GameObject.FindWithTag("Player");

        if (tmpPlayer != null)
        {
            ForSpawn = Instantiate(Bullet, m_FirePosition.position, transform.rotation) as Bullet_Script;
            Vector2 vec = tmpPlayer.transform.position - transform.position;
            ForSpawn.SetDirection(vec.normalized);
        }
    }
}
