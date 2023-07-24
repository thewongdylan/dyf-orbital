using System;
using Unisave.Facets;
using Unisave.Facades;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PlayerDataFacet : Facet
{
    public PlayerEntity GetPlayer(string playerToken)
    {
        PlayerEntity player = DB.TakeAll<PlayerEntity>()
            .Filter(e => e.playerToken == playerToken)
            .First();

        if (player == null) // no entity with this token
        {
            player = new PlayerEntity();
            player.playerToken = playerToken;
            player.Save(); // insert new document
        }

        player.lastSeenAt = DateTime.UtcNow;
        player.Save(); // update the existing document

        return player;
    }

    public void StorePlayer(string playerToken, PlayerEntity uploadedPlayer)
    {
        PlayerEntity playerFromDatabase = this.GetPlayer(playerToken);
        playerFromDatabase.FillWith(uploadedPlayer);
        playerFromDatabase.Save();
        Debug.Log("Player data stored");
    }

    public void LoadPlayer(string playerToken, PlayerEntity uploadedPlayer)
    {
        PlayerEntity playerFromDatabase = this.GetPlayer(playerToken);
        // SceneManager.LoadScene(playerFromDatabase.lastSceneIndex);
        Debug.Log("Player data loaded");
        
        // Debug.Log("Loaded token: " + uploadedPlayer.playerToken);
        // Debug.Log("Loaded current health: " + uploadedPlayer.currentHealth);
    }
}