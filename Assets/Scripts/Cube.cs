using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    BoxCollider col;
<<<<<<< HEAD
=======
    public Manager manager;
    public int number;
    public int numberCell;
>>>>>>> 6520087ad86fe3a54312e8146cc67cc475fbd3fe

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnMouseDown()
    {
<<<<<<< HEAD
    
             col.enabled = false;
             RaycastHit hit;

=======
        if(!manager.isWin)
        {
            col.enabled = false;
            RaycastHit hit;
>>>>>>> 6520087ad86fe3a54312e8146cc67cc475fbd3fe
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

<<<<<<< HEAD
        Debug.Log("true");
    }


}
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            numberCell = other.transform.GetComponent<NumberCell>().numberCell;
            manager.win();
        }
    }
}
>>>>>>> 6520087ad86fe3a54312e8146cc67cc475fbd3fe
