using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int HealthPoint = 100;
    public Text TableHealth;
    public GameObject DeadTable;
    public bool isPlayer;
    public GameObject Render;

    private GameObject _render;
    private int _currentHealth;
    private Color _startColor;

    private void Start()
    {
        _currentHealth = HealthPoint;
        _startColor = Render.GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        if (TableHealth && isPlayer)
        {
            TableHealth.text = "Здоровье: " + _currentHealth.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

       Render.GetComponent<Renderer>().material.color = Color.Lerp(Color.red,_startColor, 1.0f * _currentHealth / HealthPoint);

        if (_currentHealth <= 0)
        {
            if (isPlayer && DeadTable)
            {
                DeadTable.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Destroy(gameObject);
            }
         
        }
    }
}
