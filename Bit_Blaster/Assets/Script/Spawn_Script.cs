using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn_Script : MonoBehaviour {

    private int m_Count; // 갯수
    private int m_MaxCount; // 최대 생성 수
    private float m_SpawnRate1; // 스폰 주기 invoke 함수 실행 주기
    private int m_SpawnRate2; // 랜덤의 범위

    private Vector2 m_SpawnLocation; // 스폰 위치
    private float m_MinLocation; // 최소 스폰 위치
    private int m_Direction; // 스폰 벽 위치
    private FlightObject_Script Object; // 생성용 객체
    private float m_Time; // 게임 시간 경과

    public FlightObject_Script[] m_Prefab; // 적 종류 배열
    public GameManager m_Map; // 기준 맵

    void Awake()
    {
        m_MinLocation = 1;
        m_Count = 0;
        m_MaxCount = 30;
        m_SpawnRate1 = 1f;
        m_SpawnRate2 = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Time.timeScale = 0;
 

        m_Count = transform.childCount;

        if (m_Count == m_MaxCount || Time.timeScale == 0)
            CancelInvoke("SpawnManager");
        else if (!IsInvoking() && m_Count <= m_MaxCount && Time.timeScale != 0)
            InvokeRepeating("SpawnManager", 1, m_SpawnRate1);
    }

    void FixedUpdate()
    {
        m_Time += Time.deltaTime;
    }

    /* 스폰 관련 함수들 */

    void SpawnManager()
    {
        int index = 0; 

        m_Direction = (Random.Range(0, m_SpawnRate2)); // 이걸로도 스폰 주기 조절 가능

        if (m_Direction > 0 && m_Direction < 5)
        {
            /* 난이도 조절 */

            if (m_Time > 5)
            {
                Random.Range(0, 2);
                m_SpawnRate2 = 10;
            }
                
            if (m_Time > 20)
            {
                m_SpawnRate1 = 0.5f;
                index = Random.Range(1, 2);
                m_SpawnRate2 = 8;
            }
            if(m_Time > 35)
            {
                m_SpawnRate1 = 0.3f;
                index = Random.Range(0, 3);
            }
            if(m_Time > 50)
            {
                m_SpawnRate1 = 0.3f;
                m_MaxCount = 100;
                index = Random.Range(0, m_Prefab.Length);
            }
            if (m_Time > 80)
            {
                m_SpawnRate1 = 0.1f;
                m_SpawnRate2 = 5;
                m_MaxCount = 150;
                index = Random.Range(0, m_Prefab.Length);
            }

            Object = m_Prefab[index].GetComponent<FlightObject_Script>();

            /* 나오는 지점을 4부분으로 나누어서 생성 */
            switch (m_Direction) 
            {              
                case 1: // 위
                    SpawnSpawnStraight(Vector2.down, new Vector2(Random.Range(-m_Map.X+ m_MinLocation, m_Map.X- m_MinLocation), m_Map.Y), index);
                    break;
                case 2: // 아래
                    SpawnSpawnStraight(Vector2.up, new Vector2(Random.Range(-m_Map.X+ m_MinLocation, m_Map.X- m_MinLocation), -m_Map.Y), index);
                    break;
                case 3: // 오른쪽
                    SpawnSpawnStraight(Vector2.left, new Vector2(m_Map.X, Random.Range(-m_Map.Y+ m_MinLocation, m_Map.Y- m_MinLocation)), index);
                    break;
                case 4: // 왼쪽
                    SpawnSpawnStraight(Vector2.right, new Vector2(-m_Map.X, Random.Range(-m_Map.Y+ m_MinLocation, m_Map.Y- m_MinLocation)), index);
                    break;
            }

            if (GameObject.FindWithTag("Player") != null && m_Time > 80)
                SpawnToPlayer(new Vector2(Random.Range(-m_Map.X + m_MinLocation, m_Map.X - m_MinLocation), Random.Range(-m_Map.Y + m_MinLocation, m_Map.Y - m_MinLocation)), index);
        }
    }

    void SpawnSpawnStraight(Vector2 p_Objectdirection,Vector2 p_SpawnLocation,int p_index) // 오브젝트 생성 함수
    {
        FlightObject_Script ForSpawn;

        m_SpawnLocation = p_SpawnLocation;
        ForSpawn = Instantiate(Object, p_SpawnLocation, Quaternion.identity) as FlightObject_Script;
        ForSpawn.SetDirection(p_Objectdirection);

        ForSpawn.transform.parent = this.transform;
        m_Count++;
    }
    void SpawnToPlayer(Vector2 p_SpawnLocation, int p_index)
    {
        FlightObject_Script ForSpawn;
        Vector2 vec;

        m_SpawnLocation = p_SpawnLocation;
        ForSpawn = Instantiate(Object, p_SpawnLocation, Quaternion.identity) as FlightObject_Script;

        vec = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position - p_SpawnLocation; // 플레이어를 향한 벡터
        ForSpawn.SetDirection(vec.normalized);

        ForSpawn.transform.parent = this.transform;
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
