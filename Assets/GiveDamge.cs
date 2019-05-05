using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamge : MonoBehaviour
{
    public int Damage = 20;

    private float _timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DamageGive(other));
        }
    }

    IEnumerator DamageGive(Collider other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(Damage);
        yield return new WaitForSeconds(5f);
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

}
