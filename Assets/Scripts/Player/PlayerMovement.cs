using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _playerNormalSpeed = 6.0f;
    public float _playerSprintSpeed = 12.0f;
    public float _gravity = -9.8f;
    private CharacterController _characterController;
    private float _playerSpeed;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerSpeed = _playerNormalSpeed;
    }


    void Update()
    {
        //Здесь смотрим зажат ли левый шифт, если да меняем скорость игрока с обычной на спринт, если нет - наоборот.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _playerSpeed = _playerSprintSpeed;
        }
        else
        {
            _playerSpeed = _playerNormalSpeed;
        }

        float deltaX = Input.GetAxis("Horizontal") * _playerSpeed;
        float deltaZ = Input.GetAxis("Vertical") * _playerSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _playerSpeed);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
