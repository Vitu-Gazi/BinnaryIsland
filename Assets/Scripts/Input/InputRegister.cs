using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRegister : Singleton<InputRegister>
{
    Vector3 direction = new Vector3();

    private bool pause;

    public Action<Vector3> MovePlayer;
    public Action<float> Shooting;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            pause = !pause;
        }


        Shoot();

        if (Input.GetAxis("Jump") != 0)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction.x != 0)
        {
            direction.y = 0;
        }

        MovePlayer?.Invoke(direction);
    }
    private void Shoot()
    {
        Shooting?.Invoke(Input.GetAxis("Jump"));
    }
}
