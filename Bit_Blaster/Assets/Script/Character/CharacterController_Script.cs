using UnityEngine;
using System.Collections;

public class CharacterController_Script : FlightObject_Script {

    
    
    public GameObject m_Bullet; // 총알
    public float m_FireRate = 0.2f; // 공격 딜레이
    public Transform m_RightFirePosition; // 오른쪽 발사 위치
    public Transform m_LeftFirePosition; // 왼쪽 발사 위치
	public Transform m_MidFirePosition; // 중앙 발사 위치
    public GameObject m_FireSound; // 발사 소리
    public GameObject m_MovingSound; // 이동 소리
    public GameObject m_DestroyedSound; // 죽는 소리

    private Bullet_Script Bullet; // 총알 스폰용
    private bool m_IsAlive = true;  // 살아있니? ㄴㄴ
    float dirX = 1;
    float dirY = 1;
	bool side = true, mid = false, guided = false;
    
    

	void Start () 
    {
		//Bullet = SetBullet(m_Bullet, 3);/*.GetComponent<Bullet_Script>()*/;
		SetBullet(m_Bullet, 3);
		m_Velocity = 5f;
        //InvokeRepeating("FireBullet", 0.1f, m_FireRate);
        m_Rigid.velocity = m_Direction * m_Velocity;
        guided = false;

    }
	
    void Update()
    {
        if (!(Input.GetAxis("360_P1_Horizontal") == 0 && Input.GetAxis("360_P1_Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            dirX = Input.GetAxis("360_P1_Horizontal") + Input.GetAxis("Horizontal");
            dirY = Input.GetAxis("360_P1_Vertical") + Input.GetAxis("Vertical");
        }
    }

	void FixedUpdate () 
    {
	    if(!m_IsAlive)
        {
            GameManager.GameOver();
        }
        else
        {
            Move();
        }
	}

    /* 플레이어 컨트롤 관련 함수 */

    protected void FireBullet() // 공격 처리
    {
        Bullet_Script ForSpawn;

		if (mid)
		{
			ForSpawn = Instantiate(Bullet, m_MidFirePosition.position, transform.rotation) as Bullet_Script;
			ForSpawn.SetDirection(m_Direction);
		}

		else
		{
			if (side)
			{
				if (guided) Bullet.GetComponent<GuidedBullet>().SetTarget(dirX, dirY, this.transform);
				ForSpawn = Instantiate(Bullet, m_RightFirePosition.position, transform.rotation) as Bullet_Script;
			}
			else
			{
				if (guided) Bullet.GetComponent<GuidedBullet>().SetTarget(dirX, dirY, this.transform);
				ForSpawn = Instantiate(Bullet, m_LeftFirePosition.position, transform.rotation) as Bullet_Script;
			}

			side = !side;
			ForSpawn.SetDirection(m_Direction);
		}       
    }

    protected override void Move() // 이동 처리
    {
        if (!(Input.GetAxis("360_P1_Horizontal") == 0 && Input.GetAxis("360_P1_Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            SetDirection(new Vector2(dirX, dirY).normalized);
            m_Rigid.velocity = m_Direction * m_Velocity;
        }
    }

    protected void Dash() // 대쉬
    {

    }

    private void OnTriggerEnter2D(Collider2D col) // 충돌 처리
    {
        if (col.gameObject.tag == "Item") // 아이템 적용 처리
        {
            SetBullet(col.GetComponent<Item_Script>().m_ItemArray[col.GetComponent<Item_Script>().GetItemIndex()], col.GetComponent<Item_Script>().GetItemIndex() + 1);           
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

    public void SetBullet(GameObject p_Bullet, int itemIndex)
    {
        m_Bullet = p_Bullet;
        Bullet = m_Bullet.GetComponent<Bullet_Script>();
        m_FireRate = Bullet.GetFireRate();
        CancelInvoke();
        InvokeRepeating("FireBullet", 0.1f, m_FireRate);

		if (itemIndex == 1) mid = true;
		else mid = false;

		if (itemIndex == 3) guided = true;
		else guided = false;
	}
}
