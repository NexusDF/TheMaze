using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float rotateSpeed = 360f;
    public Transform target;

    private PlayerMotor motor;
    private Animator playerAnimations;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        playerAnimations = GetComponent<Animator>();
    }

 
    void Update()
    {
        Animation();
        Rotation();
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _yMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _yMove;

        Vector3 _moveDirection = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_moveDirection);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0 , -90, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0 , 90, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 0, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 180, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, -135, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, -45, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 45, 0), rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 135, 0), rotateSpeed * Time.deltaTime);
    }

    void Animation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            playerAnimations.SetBool("Move", true);
        else
            playerAnimations.SetBool("Move", false);
    }
}
