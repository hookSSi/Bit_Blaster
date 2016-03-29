using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour
{

    public float characterSpeed = 2;

    void Start ()
    {
	    
	}
	

	void Update ()
    {
        move();

    }

    void move()
    {
        float dirX = Input.GetAxis("Horizontal");

        float dirY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(dirX, dirY);

        GetComponent<Rigidbody2D>().velocity = movement * characterSpeed;

    }

}
