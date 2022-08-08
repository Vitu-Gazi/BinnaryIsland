using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : AbstarctMover
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        InputRegister.Instance.MovePlayer += Moving;
    }

    private void OnDisable()
    {
        InputRegister.Instance.MovePlayer -= Moving;
    }

    protected override void Moving(Vector3 direction)
    {
        if (entityState.State == CharacterState.NONACTIVE)
        {
            return;
        }

        direction.x *= horizontalSpeed * Time.deltaTime;
        direction.y *= verticalSpeed * Time.deltaTime;

        characterController.Move(direction);
    }
}
