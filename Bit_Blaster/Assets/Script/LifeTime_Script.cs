using UnityEngine;
using System.Collections;

public class LifeTime_Script : MonoBehaviour {

    public float m_Time;

	void FixedUpdate ()
    {
        m_Time -= Time.deltaTime;

	    if(m_Time < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
