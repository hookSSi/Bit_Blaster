using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {


    private int m_MaxCount; // 최대 생성 수
    private int m_Count;
    private float m_SpawnRate; // 스폰 주기
    private int m_SpawnLocation; // 스폰 위치
    private FlightObject_Script ForSpawn;

    public FlightObject_Script m_Prefab;
    public Map_Script m_Map;
	
    void Awake()
    {
        m_Count = 0;
        m_MaxCount = 100;
        m_SpawnRate = 1;

        if (m_Count > m_MaxCount)
            CancelInvoke("Spawn");
        else if(!IsInvoking() && m_Count <= m_MaxCount)
            InvokeRepeating("Spawn", 1, m_SpawnRate);
    }

	void Update ()
    {
      
    }

    void Spawn() // 스폰
    {
        SetDirection(Random.Range(1, 4));

        switch (m_SpawnLocation) /* 나오는 지점을 4부분으로 나누어서 생성 */
        {
            case 1: // 위
                ForSpawn = Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), m_Map.Y), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.down);
                break;
            case 2: // 아래
                ForSpawn = Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), -m_Map.Y), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.up);
                break;
            case 3: // 오른쪽
                ForSpawn = Instantiate(m_Prefab, new Vector2(m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.left);
                break;
            case 4: // 왼쪽
                ForSpawn = Instantiate(m_Prefab, new Vector2(-m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity) as FlightObject_Script;
                ForSpawn.SetDirection(Vector2.right);
                break;
        }

        m_Count++;
    }

    /* Get,Set */

    public void SetDirection(int p_SpawnLocation)
    {
        m_SpawnLocation = p_SpawnLocation;
    }
}
