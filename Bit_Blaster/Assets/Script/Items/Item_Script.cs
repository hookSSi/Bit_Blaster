using UnityEngine;
using System.Collections;

public class Item_Script : FlightObject_Script
{
    public GameObject[] m_ItemArray;

    private int m_RangeMin = 0;
    private int m_RangeMax;
    private int m_ItemIndex;
	private Transform m_target;


	// Use this for initialization
	void Start ()
	{
        m_RangeMax = m_ItemArray.Length;
        m_ItemIndex = Random.Range(m_RangeMin, m_RangeMax);
        m_Velocity = 1.5f;
	}
	
	void FixedUpdate()
	{
		Move();

        if(m_Velocity <= 4)
            m_Velocity += Time.deltaTime * 0.3f;
	}

	protected override void Move()
	{
		if (GameObject.FindWithTag("Player") != null)
		{
			m_target = GameObject.FindGameObjectWithTag("Player").transform;
			Vector2 vec = m_target.position - transform.position;
			SetDirection(vec.normalized);
			m_Rigid.velocity = m_Direction * m_Velocity;
		}
	}

	public int GetItemIndex()
	{
        return m_ItemIndex;
	}
}
