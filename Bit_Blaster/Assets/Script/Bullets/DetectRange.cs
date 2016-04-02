using UnityEngine;
using System.Collections;

public class DetectRange : PlayerBullet
{
	public GameObject sprite;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy") sprite = col.gameObject;
	}
}
