using UnityEngine;
using System.Collections;

public class MoveItem : FlightObject_Script
{
    public GameObject[] m_ItemArray;

    private int m_RangeMin = 0;
    private int m_RangeMax = 2;
    private int m_ItemIndex;
	private Transform m_target;


	// Use this for initialization
	void Start ()
	{
        m_ItemIndex = Random.Range(m_RangeMin, m_RangeMax);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();
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
