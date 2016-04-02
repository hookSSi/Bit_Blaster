using UnityEngine;
using System.Collections;

public class EnemyGray_script : Enemy_script {

	void Awake ()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
        m_Velocity = 1f;
        m_HealthPoint = 10;
        m_FireRate = 0.8f;
        m_Score = 500;
        m_DropChance = 10;
    }

    protected override void FireBullet() // 공격 처리
    {
        for (int i = 0; i < 7; i++)
        {
            //m_Bullet.GetComponent<MoveBullet1>().SetAngle((GetEulerAngleZ() - 30) + (i * 10));
            Instantiate(m_Bullet, m_FirePosition.position, Quaternion.identity);
        }
    }
}
