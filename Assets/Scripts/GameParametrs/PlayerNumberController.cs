using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerNumberController : Singleton<PlayerNumberController>
{
    private List<PlayerCharacter> players = new List<PlayerCharacter>();

    private void Start()
    {
        players = FindObjectsOfType<PlayerCharacter>().ToList();
    }

    public void RemovePlayersNumber (PlayerCharacter player)
    {
        players.Remove(player);

        if (players.Count <= 0)
        {
            EndGameController.Instance.EndGame(false);
        }
    }
    public void AddPlayersNumber(PlayerCharacter player)
    {
        players.Add(player);
    }
}
