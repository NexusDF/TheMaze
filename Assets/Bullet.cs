using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed = 5;
    public int Damage = 10;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Destroy(gameObject, 0.4f);
        }
    }
}
