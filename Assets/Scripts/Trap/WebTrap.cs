using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTrap : MonoBehaviour, IDamagable
{
    private EntityState playerState;

    private void OnTriggerEnter(Collider other)
    {
        if (playerState != null)
        {
            return;
        }

        if (other.TryGetComponent(out playerState) && other.CompareTag("Player"))
        {
            playerState.SetState(CharacterState.NONACTIVE);
            playerState.transform.position = transform.position;

            PlayerNumberController.Instance.RemovePlayersNumber(playerState.GetComponent<PlayerCharacter>());
        }
    }

    public void GetDamage()
    {
        playerState?.SetState(CharacterState.ACTIVE);
        PlayerNumberController.Instance.AddPlayersNumber(playerState?.GetComponent<PlayerCharacter>());
        Destroy(gameObject);
    }
}
