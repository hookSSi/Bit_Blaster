using UnityEngine;
using System.Collections;

public class DeadCharacter : MonoBehaviour
{

	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D m_Other)
    {
        if (m_Other.tag == "Enemy")
        {
            GameObject[] Enemys = GameObject.FindGameObjectsWithTag("PlayerBullet");

            foreach (GameObject Enemy in Enemys)
            {
                Destroy(Enemy);
            }

            GameObject[] Bullets = GameObject.FindGameObjectsWithTag("PlayerBullet");

            foreach (GameObject Bullet in Bullets)
            {
                Destroy(Bullet);
            }



            Destroy(gameObject);
        }
    }
}
