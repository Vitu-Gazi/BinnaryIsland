using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : Singleton<EndGameController>
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private bool endGameStatus;

    public Action<CharacterState> EndTheGame;
    public Action<int> SetPlayerNumber;


    public void EndGame (bool value)
    {
        if (endGameStatus != default)
        {
            return;
        }

        if (value)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }

        EndTheGame?.Invoke(CharacterState.NONACTIVE);
    }
}
