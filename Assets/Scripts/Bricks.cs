﻿using UnityEngine;

public class Bricks : MonoBehaviour
{
    public Bricks[] brick;
    public int count = 4;
    public bool flag;
    public int x, y;
    public Material _Blue;
    public Material _Red;

    private void OnMouseDown()
    {
        brick[x * count + y].flag = !brick[x * count + y].flag;
        for (int i = 0; i < count; i++)
        {
            brick[i * count + y].flag = !brick[i * count + y].flag;
        }
        for (int i = 0; i < count; i++)
        {
            brick[x * count + i].flag = !brick[x * count + i].flag;
        }
        for (int i = 0; i < brick.Length; i++)
        {
            if (brick[i].flag == true)
            {
                brick[i].GetComponent<MeshRenderer>().material = _Red;
            }
            else brick[i].GetComponent<MeshRenderer>().material = _Blue;
        }
    }
}