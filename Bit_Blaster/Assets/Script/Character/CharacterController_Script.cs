using UnityEngine;
using System.Collections;

public class CharacterController_Script : FlightObject_Script {

    private bool m_IsAlive = true;  // 살아있니?
    public int[] m_Euquipments; // 아이템 배열
    private GameObject m_Bullet; // 총알
    private float m_FireRate = 0.2f; // 공격 딜레이
    public GameObject m_FirePosition; // 발사 위치
   
    public GameObject m_FireSound; // 발사 소리
    public GameObject m_MovingSound; // 이동 소리
    public GameObject m_DestroyedSound; // 죽는 소리


    float dirX = 0;
    float dirY = 0;
    int itemIndex;
    bool canAttack = true;
    

	void Start () 
    {
        m_Velocity = 3.5f;
	}
	
    void Update()
    {
        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
        }
    }

	void FixedUpdate () 
    {
	    if(!m_IsAlive)
        {
            Destroy(gameObject);
            Application.LoadLevel("GameOver");
        }
        else
        {
            Move();
        }
	}

    protected override void Move()
    {
        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            SetDirection(new Vector2(dirX, dirY));
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            itemIndex = col.GetComponent<MoveItem>().GetItemNumber();
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyBullet")
        {
            Instantiate(m_DestroyedSound);
            m_IsAlive = false;
        }    
    }

    /* Get,Set의 구역 */

    public void SetVelocity(float p_Velocity)
    {
        m_Velocity = p_Velocity;
    }
}
