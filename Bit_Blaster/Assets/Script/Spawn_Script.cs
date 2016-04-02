using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn_Script : MonoBehaviour {

    private int m_Count; // 갯수
    private int m_MaxCount; // 최대 생성 수
    private float m_SpawnRate1; // 스폰 주기 invoke 함수 실행 주기
    private int m_SpawnRate2; // 랜덤의 범위
    private Vector2 m_SpawnLocation; // 스폰 위치
    private int m_Direction; // 스폰 벽 위치
    private FlightObject_Script temp; // 생성용 객체
    private float m_Time; // 게임 시간 경과

    public FlightObject_Script[] m_Prefab; // 적 종류 배열
    public Map_Script m_Map; // 기준 맵

    void Awake()
    {
        m_Count = 0;
        m_MaxCount = 30;
        m_SpawnRate1 = 1f;
        m_SpawnRate2 = 5;
    }

    void Update()
    {
        m_Count = transform.GetChildCount();

        if (m_Count == m_MaxCount)
            CancelInvoke("SpawnManager");
        else if (!IsInvoking() && m_Count <= m_MaxCount)
            InvokeRepeating("SpawnManager", 1, m_SpawnRate1);
    }

    void FixedUpdate()
    {
        m_Time += Time.deltaTime;
    }

    void SpawnManager() // 스폰
    {
        int index = 0; 

        m_Direction = (Random.Range(1, m_SpawnRate2)); // 이걸로도 스폰 주기 조절 가능

        if(m_Direction > 0 && m_Direction < 5)
        {
            /* 난이도 조절 */

            if (m_Time > 5)
                index = Random.Range(0, 2);
            if (m_Time > 20)
                index = Random.Range(1, 2);
            if(m_Time > 35)
            {
                m_SpawnRate1 = 0.3f;
                index = Random.Range(0, 3);
            }

            /* 나오는 지점을 4부분으로 나누어서 생성 */

            switch (m_Direction) 
            {
                case 1: // 위
                    Spawn(Vector2.down, new Vector2(Random.Range(-m_Map.X, m_Map.X), m_Map.Y), index);
                    break;
                case 2: // 아래
                    Spawn(Vector2.up, new Vector2(Random.Range(-m_Map.X, m_Map.X), -m_Map.Y), index);
                    break;
                case 3: // 오른쪽
                    Spawn(Vector2.left, new Vector2(m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), index);
                    break;
                case 4: // 왼쪽
                    Spawn(Vector2.right, new Vector2(-m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), index);
                    break;
            }
        }
    }

    void Spawn(Vector2 p_Objectdirection,Vector2 p_SpawnLocation,int p_index) // 오브젝트 생성 함수
    {     
        m_SpawnLocation = p_SpawnLocation;
        temp = Instantiate(m_Prefab[p_index], m_SpawnLocation, Quaternion.identity) as FlightObject_Script;
        temp.SetDirection(p_Objectdirection);

        temp.transform.parent = this.transform;
        m_Count++;
    }

    /* Get,Set */

    public Vector2 GetSpawnLocation()
    {
        return m_SpawnLocation;
    }

    public void SetDirection(Vector2 p_SpawnLocation)
    {
        m_SpawnLocation = p_SpawnLocation;
    }

    public void SetMaxCount(int p_MaxCount)
    {
        m_MaxCount = p_MaxCount;
    }

    public void SetSpawnRate1(float p_SpawnRate1)
    {
        m_SpawnRate1 = p_SpawnRate1;
    }


    public void SetSpawnRate2(int p_SpawnRate2)
    {
        m_SpawnRate2 = p_SpawnRate2;
    }
}
