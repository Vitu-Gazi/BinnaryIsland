using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamagable
{
    [SerializeField] private EntityState playerState;

    public void GetDamage()
    {
        if (playerState.State == CharacterState.NONACTIVE)
        {
            return;
        }

        EndGameController.Instance.EndGame(false);
        Destroy(gameObject);
    }
}
