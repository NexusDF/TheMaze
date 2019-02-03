using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    public float moveSpeed = 10f;

    private CharacterController _char;

    private float _MovX;
    private float _MovY;

    void Start()
    {
        _char = GetComponent<CharacterController>();
    }

    void Update()
    {
        _MovX = Input.GetAxis("Horizontal");
        _MovY = Input.GetAxis("Vertical");

        Vector3 movHorizontal = transform.right * _MovX;
        Vector3 movVertical = transform.forward * _MovY;

        Vector3 moveVector = (movHorizontal + movVertical).normalized * moveSpeed * Time.deltaTime;

        _char.Move(moveVector);
    }

}
