using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarleyBreak : MonoBehaviour
{
    private int[] currentIndex;
    private GameObject[] triggers;
    private int[] cells;

    private bool[] isTrue = new bool[16];

    private Grid grid = new Grid();

    public int NumberCell;
    public LayerMask noTrigger;

    private void Start()
    {
        //ChecksWin();
    }

    private void OnMouseDown()
    {
        if (!Physics.Linecast(transform.position,transform.position + transform.right, noTrigger))
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        else if (!Physics.Linecast(transform.position, transform.position - transform.right, noTrigger))
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        }
        else if (!Physics.Linecast(transform.position, transform.position + transform.up, noTrigger))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (!Physics.Linecast(transform.position, transform.position - transform.up, noTrigger))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        int count = 0;
        if (NumberCell == other.transform.GetComponent<BarleyBreak>().NumberCell)
        {
            //хз
            Debug.Log("Ok..");
        }
        else
        {

        }
        Debug.Log(count.ToString());
        
    }

    public void ChecksWin()
    {
        int count = 0;
        for (int i = 0; i < grid.triggerIndex.Length; i++)
        {
            if (grid.triggerIndex[i].GetComponent<BarleyBreak>().NumberCell != cells[i])
            {
                count = 0;
                return;
            }
            else
            {
                count++;
                if (count >= 15)
                {
                    Debug.Log("Win");
                }
            }

        }
        
    }

}

