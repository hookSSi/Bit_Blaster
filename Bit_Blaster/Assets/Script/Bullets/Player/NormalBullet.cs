using UnityEngine;
using System.Collections;

public class NormalBullet: Bullet_Script
{
    void Start()
    {
        m_Velocity = 10f; // 속도
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") Destroy(gameObject);
    }
}
