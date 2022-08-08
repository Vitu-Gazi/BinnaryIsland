using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : Singleton<StartGameController>
{
    public Action<CharacterState> StartTheGame;

    private void Start()
    {
        StartTheGame?.Invoke(CharacterState.ACTIVE);
    }
}
