using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    #region Self Variables

    #region Public Variables

    public MovementTypes Types;

    #endregion

    #region Serialized Variables


    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private float speed = 6;
    #endregion

    #region Private Variables

    private Vector2 _inputValues;
    #endregion

    #region Private Variables

    private bool _isReadyToMove;
    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove)
        {
            switch (Types)
            {
                case MovementTypes.Velocity:
                    {
                        MovePlayerWithVelocity();
                        break;
                    }
                case MovementTypes.AddForce:
                    {
                        MovePlayerWithAddForce();
                        break;
                    }
                case MovementTypes.Transform:
                    {
                        MovePlayerWithTransform();
                        break;
                    }
            }

        }
        else StopPlayer();
    }

    public void SetMovementAvailable()
    {
        _isReadyToMove = true;
    }

    public void SetMovementUnavailable()
    {
        _isReadyToMove = false;
    }

    public void UpdateInputData(Vector2 inputValue)
    {
        _inputValues = inputValue;
    }

    private void MovePlayerWithVelocity()
    {
        Rigidbody.velocity = new Vector3(_inputValues.x * speed, Rigidbody.velocity.y, _inputValues.y * speed);
    }

    private void MovePlayerWithAddForce()
    {
        Rigidbody.AddForce(new Vector3(_inputValues.x * speed, Rigidbody.velocity.y, _inputValues.y * speed), ForceMode.Force);

    }

    private void MovePlayerWithTransform()
    {
        transform.position += new Vector3(_inputValues.x * speed * Time.deltaTime, 0, _inputValues.y * speed * Time.deltaTime);
    }

    private void StopPlayer()
    {
        Rigidbody.velocity = new Vector3(0, Rigidbody.velocity.y, 0);
        Rigidbody.angularVelocity = Vector3.zero;
    }
}
