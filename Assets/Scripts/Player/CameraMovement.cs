using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum RotationAxis
    {
        X,
        Y
    }

    public RotationAxis _axis = RotationAxis.X;
    public float _rotationSpeedHorisontal = 3.0f;
    public float _rotationSpeedVertical = 3.0f;
    public float maxVerticalAngle = 45.0f;
    public float minVerticalAngle = -45.0f;

    private float _rotationX = 0;


    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_axis == RotationAxis.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHorisontal, 0);
        }
        else if (_axis == RotationAxis.Y)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVertical;
            _rotationX = Mathf.Clamp(_rotationX, minVerticalAngle, maxVerticalAngle);
            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
