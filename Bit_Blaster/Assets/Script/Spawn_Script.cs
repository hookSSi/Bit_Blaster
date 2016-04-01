using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn_Script : MonoBehaviour {


    private int m_MaxCount; // 최대 생성 수
    private float m_SpawnRate1; // 스폰 주기 invoke 함수 실행 주기
    private int m_SpawnRate2; // 랜덤의 범위
    private int m_SpawnLocation; // 스폰 위치
    private FlightObject_Script ForSpawn; // 생성용 객체

    public FlightObject_Script[] m_Prefab; // 적 종류 배열
    public Map_Script m_Map; // 기준 맵

    public int m_Count; // 갯수
	
    void Awake()
    {
        m_Count = 0;
        m_MaxCount = 30;
        m_SpawnRate1 = 0.1f;
        m_SpawnRate2 = 5;
    }

    void Update()
    {
        Debug.Log(m_Count);
        m_Count = transform.GetChildCount();

        if (m_Count == m_MaxCount)
            CancelInvoke("Spawn");
        else if (!IsInvoking() && m_Count <= m_MaxCount)
            InvokeRepeating("Spawn", 1, m_SpawnRate1);
    }

    void Spawn() // 스폰
    {
        SetDirection(Random.Range(1, m_SpawnRate2)); // 이걸로도 스폰 주기 조절 가능

        switch (m_SpawnLocation) /* 나오는 지점을 4부분으로 나누어서 생성 */
        {
            case 1: // 위
                ForSpawn = Instantiate(m_Prefab[Random.Range(0,2)], new Vector2(Random.Range(-m_Map.X, m_Map.X), m_Map.Y), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.down);
                break;
            case 2: // 아래
                ForSpawn = Instantiate(m_Prefab[Random.Range(0, 2)], new Vector2(Random.Range(-m_Map.X, m_Map.X), -m_Map.Y), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.up);
                break;
            case 3: // 오른쪽
                ForSpawn = Instantiate(m_Prefab[Random.Range(0, 2)], new Vector2(m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.left);
                break;
            case 4: // 왼쪽
                ForSpawn = Instantiate(m_Prefab[Random.Range(0, 2)], new Vector2(-m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.right);
                break;
        }
        ForSpawn.transform.parent = this.transform;
        m_Count++;
    }

    /* Get,Set */

    public void SetDirection(int p_SpawnLocation)
    {
        m_SpawnLocation = p_SpawnLocation;
    }
}
