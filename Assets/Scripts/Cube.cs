using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider col;
    public Manager manager;
    public int number;
    public int NumberCell;

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
        if(!manager.isWin)
        {
            col.enabled = false;
            RaycasHit hit;
            if (!Physics.Linecast(transform.position, transform.position + transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.right, out hit))
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
            else if (!Physics.Linecast(transform.position, transform.position + transform.forward, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
            else if (!Physics.Linecast(transform.position, transform.position + -transform.forward, out hit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
            col.enabled = true;
        }
    }

    private void OnTriggerEnter()
    {
        if (other.tag == "trigger")
        {
            NumberCell = other.transform.GetComponent<NumberCell>().NumberCell;
        }
    }
}
