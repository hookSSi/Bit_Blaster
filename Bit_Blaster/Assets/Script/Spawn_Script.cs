using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {


    private int m_ObjectCount; // 최대 생성 수
    private float m_SpawnRate; // 스폰 주기
    private Direction m_SpawnLocation; // 스폰 위치
    private FlightObject_Script ForSpawn;

    public FlightObject_Script m_Prefab;
    public Map_Script m_Map;

    public enum Direction
    {
        Up, Down, Right, Left
    }
	
    void Awake()
    {
        m_ObjectCount = 10;
        m_SpawnRate = 1;
        SetDirection(Direction.Up);
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
            SetDirection(Direction.Up);
        if (Input.GetKeyDown(KeyCode.S))
            SetDirection(Direction.Down);
        if (Input.GetKeyDown(KeyCode.A))
            SetDirection(Direction.Left);
        if (Input.GetKeyDown(KeyCode.D))
            SetDirection(Direction.Right);

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("UP");
            Spawn();
        }
           
    }

    void Spawn() // 스폰
    {
        ForSpawn = m_Prefab;

        switch (m_SpawnLocation)
        {
            case Direction.Up:
                ForSpawn.SetDirection(Vector2.down);
                Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), m_Map.Y), Quaternion.identity);
                break;
            case Direction.Down:
                ForSpawn.SetDirection(Vector2.up);
                Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), -m_Map.Y), Quaternion.identity);
                break;
            case Direction.Right:
                ForSpawn.SetDirection(Vector2.left);
                Instantiate(m_Prefab, new Vector2(m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity);
                break;
            case Direction.Left:
                ForSpawn.SetDirection(Vector2.right);
                Instantiate(m_Prefab, new Vector2(-m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity);
                break;
        }
    }

    /* Get,Set */

    public void SetDirection(Direction p_SpawnLocation)
    {
        m_SpawnLocation = p_SpawnLocation;
    }
}
