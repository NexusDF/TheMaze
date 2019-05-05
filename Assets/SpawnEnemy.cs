using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;

    void Start()
    {
        Spawn(10);
    }

    public void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-10, 10), -1.5f, Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}
