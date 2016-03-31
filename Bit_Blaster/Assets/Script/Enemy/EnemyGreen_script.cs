using UnityEngine;
using System.Collections;

public class EnemyGreen_script : Enemy_script
{
    void Update()
    {
        if (m_IsAlive == false)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if (m_IsAlive)
        {
            Move();
        }
    }
}
