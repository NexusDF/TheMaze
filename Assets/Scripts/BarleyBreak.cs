using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarleyBreak : MonoBehaviour
{
    private int[] currentIndex = new int[16];
    private GameObject[] trigger;
    private GameObject[] cell;

    public int NumberCell;
    public LayerMask noTrigger;

    private void Start()
    {

    }

    public void TakeIndex(GameObject[] obj)
    {
        cell = obj;
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

    /*private void OnTriggerEnter(Collider other)
    {
            currentIndex[NumberCell] = other.GetComponent<BarleyBreak>().NumberCell;
            grid.ChecksWin(currentIndex);
            for (int i = 0; i < currentIndex.Length; i++)
            {
                Debug.Log(currentIndex[i].ToString());
            }
            //Debug.Log("Trigger: " + NumberCell.ToString() + " Cell:" + currentIndex[15]);
        
        
    }*/
}

