using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    private CharacterState state;

    public CharacterState State => state;

    protected void Start()
    {
        EndGameController.Instance.EndTheGame += SetState;
        StartGameController.Instance.StartTheGame += SetState;
    }
    protected void OnDisable()
    {
        EndGameController.Instance.EndTheGame -= SetState;
        StartGameController.Instance.StartTheGame -= SetState;
    }

    public void SetState (CharacterState state)
    {
        this.state = state;
    }
}

public enum CharacterState
{
    ACTIVE,
    NONACTIVE
}
