using UnityEngine;
using System.Collections;

public class EnemyBlue_script : EnemyRed_script {

    private GameObject temp;

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
        for (int i = 1; i < 36; i++)
        {
            Instantiate(m_Bullet, transform.position, Quaternion.identity);
            m_Bullet.GetComponent<Bullet_Script>().SetAngle(this.transform.eulerAngles.z + 100);
            //temp.SetAngle(temp.transform.eulerAngles.z + (i * 10));
        }

        Destroy(this.gameObject);
    }
}
