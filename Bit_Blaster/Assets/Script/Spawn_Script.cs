using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {


    private int m_ObjectCount = 10; // 최대 생성 수
    private float m_SpawnRate = 1; // 스폰 주기
    private Direction m_SpawnLocation = Direction.Down; // 스폰 위치

    public GameObject m_Prefab;
    public Map_Script m_Map;

    public enum Direction
    {
        Up, Down, Right, Left
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Spawn();
    }

    void Spawn()
    {
      //  GameObject forSpawn = m_Prefab;

        switch (m_SpawnLocation)
        {
            case Direction.Up:
<<<<<<< HEAD
                Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), m_Map.Y), Quaternion.identity);
              //  m_Prefab.SetDirection(Vector2.down);
=======
                Instantiate(m_SpawnObject, new Vector2(Random.Range(-m_Map.X, -m_Map.X), m_Map.Y), transform.rotation);
>>>>>>> b1d9c82ce9a61ef7a89a3c4c25c21c54418e2400
                break;
            case Direction.Down:               
                Instantiate(m_Prefab, new Vector2(Random.Range(-m_Map.X, m_Map.X), -m_Map.Y), Quaternion.identity);
               // m_Prefab.SetDirection(Vector2.up);
                break;
            case Direction.Right:                
                Instantiate(m_Prefab, new Vector2(m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity);
               // m_Prefab.SetDirection(Vector2.left);
                break;
            case Direction.Left:            
                Instantiate(m_Prefab, new Vector2(-m_Map.X, Random.Range(-m_Map.Y, m_Map.Y)), Quaternion.identity);
               // m_Prefab.SetDirection(Vector2.right);
                break;
        }
    }
}
