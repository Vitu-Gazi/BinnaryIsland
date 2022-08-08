using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private FinishRegister[] finishRegisters;

    private void Start()
    {
        FinishRegister.PlayerIsEntering += CheckRegisters;
    }
    private void OnDisable()
    {
        FinishRegister.PlayerIsEntering -= CheckRegisters;
    }

    private void CheckRegisters ()
    {
        foreach (FinishRegister reg in finishRegisters)
        {
            if (!reg.IsPlayer)
            {
                return;
            }
        }

        EndGameController.Instance.EndGame(true);
    }
}
