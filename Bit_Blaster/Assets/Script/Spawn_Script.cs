using UnityEngine;
using System.Collections;

public class Spawn_Script : MonoBehaviour {

    private float m_SpawnRate = 1;
    private Direction m_SpawnDirection;

    public GameObject m_SpawnObject;
    public Map_Script m_Map;
    public enum Direction
    {
        Up, Down, Right, Left
    }


    void Awake ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void Spawn()
    {
        switch(m_SpawnDirection)
        {
            case Direction.Up:
                Instantiate(m_SpawnObject, new Vector2(Random.Range(-m_Map.X, -m_Map.X), m_Map.Y), transform.rotation);
                break;
            case Direction.Down:
                break;
            case Direction.Right:
                break;
            case Direction.Left:
                break;
        }
    }
}
