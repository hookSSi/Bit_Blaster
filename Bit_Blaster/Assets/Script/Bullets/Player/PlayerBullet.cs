using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet_Script
{
    void Start()
    {
        m_Velocity = 20f; // 속도
    }

    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") Destroy(gameObject);
    }
}
