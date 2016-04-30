using UnityEngine;
using System.Collections;

public class BigBlueEnemyBullet : Bullet_Script {

    public GameObject m_ChildBullet;
    private Bullet_Script Bullet;

    private float m_time = 0;
    private float m_ExplodeTime;

	void Start() 
    {
        m_ExplodeTime = 2;
        Bullet = m_ChildBullet.GetComponent<Bullet_Script>();
        m_Velocity = 5f;
	}

    void Update()
    {
        m_time += Time.deltaTime;

        if(m_time > m_ExplodeTime)
        {
            Explode();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") Explode();    
    }

    void Explode()
    {
        Bullet_Script ForSpawn1;

        for (int i = 0; i <= 12; i++)
        {
            ForSpawn1 = Instantiate(Bullet, transform.position, Quaternion.identity) as Bullet_Script;
            ForSpawn1.SetAngle(i * 30);
            ForSpawn1.SetVelocity(3f);
        }


        Destroy(gameObject);
    }
}
