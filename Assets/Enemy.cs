using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0,20)]
    public float Speed = 2f;

    private bool EnterPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnterPlayer = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && EnterPlayer)
        {
            transform.LookAt(other.transform);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnterPlayer = false;
        }
    }

}
