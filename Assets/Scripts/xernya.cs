using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xernya : MonoBehaviour
{

    public Transform PlayerTransform;
    public Transform[] Points;

    private int _counter = 0;

    private void Update()
    {
        PlayerTransform.position =  Vector3.MoveTowards(PlayerTransform.position,
            Points[_counter].position, Time.deltaTime);
        if (Vector3.Distance(PlayerTransform.position, Points[_counter].position) < 0.01f)
            if (++_counter >= Points.Length)
                _counter = 0;
    }
}
