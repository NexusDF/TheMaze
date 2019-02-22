using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int colum;
    public int row;
    private int size;

    private Vector3 main;

    [SerializeField]
    private GameObject cell;
    [SerializeField]
    private GameObject cellTrigger;
    private int[] index_c = new int[15];
    [SerializeField]
    private GameObject border;
    public GameObject[] cellIndex;
    public GameObject[] cellTrigerIndex;

    private void Awake()
    {
        GridCreator();
        FillTriggers(cellTrigerIndex);
        CreateBorders();
        Randomize(cellIndex);
        EditNumbe(cellIndex);
    }


    void GridCreator()
    {
        size = colum * row;

        cellIndex = new GameObject[size - 1];
        cellTrigerIndex = new GameObject[size - 1];

        for (int y = 0; y < size / row ; y++)
        {
            for (int x = 0; x < size / colum ; x++)
            {
                if (x == colum - 1 && y == row -1)
                {
                    return;
                }
                int count = y * row + x;
                cellIndex[count] = Instantiate(cell, new Vector3(x,border.transform.localScale.y * (row - 1) -y, 0), Quaternion.identity) as GameObject;
                cellTrigerIndex[count] = Instantiate(cellTrigger, new Vector3(x, border.transform.localScale.y * (row - 1) - y, 0), Quaternion.identity) as GameObject;
            }
        }
        

    }

    void FillTriggers(GameObject[] _game)
    {
        for (int i = 0; i < _game.Length; i++)
        {
            if (_game != null)
            {
                _game[i].GetComponent<BarleyBreak>().NumberCell = i;
            }
        }
    }

    void CreateBorders()
    {
        if (border != null)
        {
            float xBord = border.transform.localScale.x;
            float yBord = border.transform.localScale.y;

            for (int i = 0; i <= row; i++)
            {
                Instantiate(border, new Vector3(transform.position.x - xBord, i, 0), Quaternion.identity);
            }
            for (int i = 0; i <= colum; i++)
            {
                Instantiate(border, new Vector3(i, row * yBord, 0), Quaternion.identity);
            }
            for (int i = 0; i <= row + 1; i++)
            {
                Instantiate(border, new Vector3((transform.position.x - xBord) + i, transform.position.y - yBord, 0), Quaternion.identity);
            }
            for (int i = 0; i <= colum; i++)
            {
                Instantiate(border, new Vector3(transform.position.x + xBord * colum, i, 0), Quaternion.identity);
            }

        }

    }

    void Randomize(GameObject[] _game)
    {
        for (int i = 0; i < _game.Length - 1; i++)
        {
            bool contrains;
            int next;
            do
            {
                next = Random.Range(1, _game.Length);
                contrains = false;

                for (int index = 0; index < i; index++)
                {
                    if (_game[i] != null)
                    {
                        int n = _game[index].GetComponent<BarleyBreak>().NumberCell;
                        if (n == next)
                        {
                            contrains = true;
                            break;
                        }
                    }

                }
            } while (contrains);
            if (_game[i] != null)
            {
                _game[i].GetComponent<BarleyBreak>().NumberCell = next;
            }

        }
    }

    void EditNumbe(GameObject[] _game)
    {
        for (int i = 0; i < _game.Length; i++)
        {
            _game[i].GetComponentInChildren<TextMeshPro>().text = _game[i].GetComponent<BarleyBreak>().NumberCell.ToString();
        }
        
    }


    
}
