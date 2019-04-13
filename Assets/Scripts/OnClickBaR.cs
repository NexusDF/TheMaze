using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBaR : MonoBehaviour
{
    public List<Cell> cells = new List<Cell>();
    private BlueAndRed bar;
    private GameObject barE;
    private Transform Coor;
    private const int n = 4;
    private Material Blue;
    private Material Red;

    private void Start()
    {
        barE = GameObject.FindGameObjectWithTag("BlueAndRed");
        bar = barE.GetComponent<BlueAndRed>();
        Blue = bar._Blue;
        Red = bar._Red;
    }

    private void OnMouseOver()
    {
        cells = bar.cells;
    }

    private void OnMouseDown()
    {
        Coor = gameObject.GetComponent<Transform>();
        int x = (int)(Coor.position.x);
        int y = (int)(Coor.position.y);
        RePainting(x, y);
        Debug.Log(x);
        Debug.Log(y);
    }

    private int GetIndex(float x, float y)
    {
        return (int)(x + y * n);
    }

    private void RePainting(int x, int y)
    {
        int index = GetIndex(x, y);
        cells[index].colorFlag = !cells[index].colorFlag;
        for (int i = 0; i < n; i++)
        {
            cells[i * n + y].colorFlag = !cells[i * n + y].colorFlag;
        }
        for (int i = 0; i < n; i++)
        {
            cells[x * n + i].colorFlag = !cells[x * n + i].colorFlag;
        }
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].colorFlag)
            {
                cells[i].SetColor(Blue);
            }
            else
            {
                cells[i].SetColor(Red);
            }
        }
    }
    
    public void SetColor(Material m)
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = m;
    }
}
