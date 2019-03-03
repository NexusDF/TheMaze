using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public GameObject[] cellIndex;
    public GameObject[] triggerIndex;

    public  int column;
    public  int row;

    [SerializeField] private GameObject border;
    [SerializeField] private GameObject cell;
    [SerializeField] private GameObject cellTrigger;

    private Index[] id;
    


    private void Awake()
    {
        GridCreator(cell);
        //FillTriggers(triggerIndex);
        CreateBorders();
    }


    void Setup()
    {
        id = new Index[row * column - 1];

        for (int i = 0; i < id.Length; i++)
        {
            id[i] = new Index();
        }

        for (int i = 0; i < id.Length; i++)
        {
            //id[i] = ;
        }
    }

    void GridCreator(GameObject cell)
    {
        int gridSize = column * row;

        //cellIndex    = new GameObject[gridSize - 1]; //4x4 - 1 = 15 элементов
        //triggerIndex = new GameObject[gridSize - 1];

        for (int y = 0; y < gridSize / row ; y++)
        {
            for (int x = 0; x < gridSize / column ; x++)
            {
                if (x == column - 1 && y == row - 1)
                {
                    return; //Удаление 16 ячейки
                }

                Instantiate(cell, new Vector3(x,(row - 1) - y, 0), Quaternion.identity);
                //int count = y * row + x; //Поиск индекса и дальнейшее присваивание
                //cellIndex   [count] = Instantiate(cell, new Vector3(x,border.transform.localScale.y * (row - 1) -y, 0), Quaternion.identity) as GameObject;
                //triggerIndex[count] = Instantiate(cellTrigger, new Vector3(x, border.transform.localScale.y * (row - 1) - y, 0), Quaternion.identity) as GameObject;
            }
        }
        

    }

    /*void FillTriggers(GameObject[] _game)
    {
        for (int i = 0; i < _game.Length; i++)
        {
            if (_game != null)
            {
                _game[i].GetComponent<BarleyBreak>().NumberCell = i;
            }
        }
    }*/

    void CreateBorders()
    {

        int verticalSide = row;
        int horizontalSide = column;

        //Построение вертикальных стенок
            for (int i = -1; i <= verticalSide; i++)
            {
                Instantiate(border, new Vector3(transform.position.x - 1, i, 0), Quaternion.identity); 
                Instantiate(border, new Vector3(transform.position.x + column, i, 0), Quaternion.identity); //Вертикальные
            }

        //Построение горизонтальных стенок
            for (int i = 0; i < horizontalSide; i++)
            {
                Instantiate(border, new Vector3(i, row, 0), Quaternion.identity);
                Instantiate(border, new Vector3(i, transform.position.y - 1, 0), Quaternion.identity);
                                                                                                                              
            }
    }

    void Randomize(Index[] id)
    {
        for (int i = 0; i < id.Length; i++)
        {
            bool contrains;
            int next;
            do
            {
                next = Random.Range(1, id.Length);
                contrains = false;

                for (int index = 0; index < i; index++)
                {
                    if (id[i] != null)
                    {
                        int n = id[index].index;
                        if (n == next)
                        {
                            contrains = true;
                            break;
                        }
                    }

                }
            } while (contrains);
            if (id[i] != null)
            {
                id[i].index = next;
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
