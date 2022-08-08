using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRegister : MonoBehaviour
{
    private GameObject isPlayer;

    public bool IsPlayer => isPlayer;

    public static Action PlayerIsEntering;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            isPlayer = player.gameObject;
            PlayerIsEntering?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player) && player.gameObject == isPlayer)
        {
            isPlayer = null;
        }
    }
}
