using UnityEngine;
using System.Collections;

public class moveCharacter : Map_Script
{ 
    public float characterSpeed = 5;

    void Start()
    {

    }


    void Update()
    {
        Move();

    }

    void Move()
    {
        float dirX = Input.GetAxis("Horizontal");

        float dirY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(dirX, dirY);

        Debug.Log("X " + dirX);

        Debug.Log("Y " + dirY);

        float angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;

        gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);

        GetComponent<Rigidbody2D>().velocity = movement * characterSpeed;

    }

    void BulletFire()
    {

    }
}