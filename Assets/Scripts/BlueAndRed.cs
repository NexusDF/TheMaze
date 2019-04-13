using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAndRed : MonoBehaviour
{

    public GameObject cell;
    public int rowsCount = 4;
    public int colsCount = 4;
    public static Material Blue;
    public static Material Red;

    public Material _Blue;
    public Material _Red;
    public List<Cell> cells = new List<Cell>();
    

    void Start()
    {
        Cell.myCell = cell;

        Blue = _Blue;
        Red = _Red;

        for (int j = rowsCount - 1; j >= 0; j--)
        {
            for (int i = 0; i < colsCount; i++)
            {
                Cell c = new Cell(i, j);
                cells.Add(c);
            }
        }

        foreach (var c in cells)
        {
            c.Show();
        }

        for (int i = 0; i < cells.Count; i++)
        {
            int r = Random.Range(0, 2);
            if (r == 1)
            {
                cells[i].SetColor(Blue);
            }
            else cells[i].SetColor(Red);
            cells[i].SetFlag();
        }

    }

}

public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public static GameObject myCell { get; set; }
    public bool colorFlag = false;


    private GameObject cell;
    public MeshRenderer render = null;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Show()
    {
        cell = Object.Instantiate(myCell, new Vector3(X, Y, 0), Quaternion.identity);
        Turn();
    }

    private void Turn()
    {
        render = cell.GetComponent<MeshRenderer>();
    }
    
    public void SetColor(Material m)
    {
        render.sharedMaterial = m;
    }

    public void SetFlag()
    {
        if (render.sharedMaterial == BlueAndRed.Blue)
        {
            colorFlag = true;
        }
    }
}
