using System;
using UnityEngine;
using Unisave.Facets;
using Unisave.Facades;
using Unisave.Serialization;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace SaveFunctions
    {
    public class PlayerDataClient : MonoBehaviour
    {
        public PlayerEntity player = null;
        [SerializeField] private OsloData osloData;
        private OsloOrbs osloOrbs;
        void Start()
        {
            osloOrbs = GameObject.Find("Oslo").GetComponent<OsloOrbs>();
            Debug.Log("Downloading player data...");

            OnFacet<PlayerDataFacet>
                .Call<PlayerEntity>(
                    nameof(PlayerDataFacet.GetPlayer),
                    PlayerToken.Get()
                )
                .Then(this.OnPlayerDownloaded)
                .Done();
        }

        public void SavePlayer()
        {
            Debug.Log("Saving player data...");
            this.player.startingHealth = osloData.startingHealth;
            this.player.currentHealth = osloData.currentHealth;
            this.player.equippedOrbType = osloData.equippedOrbType;
            this.player.equippedOrbIndex = osloData.equippedOrbIndex;
            this.player.savedSceneIndex = SceneManager.GetActiveScene().buildIndex;
            osloData.savedSceneIndex = SceneManager.GetActiveScene().buildIndex;
            this.player.startingAvailableOrbs = osloData.startingAvailableOrbs;
            this.player.startingEquippedOrbType = osloData.startingEquippedOrbType;

            OnFacet<PlayerDataFacet>
                .Call(
                    nameof(PlayerDataFacet.StorePlayer),
                    PlayerToken.Get(),
                    this.player
                )
                .Then(() => {
                    Debug.Log("Player data was saved.");
                })
                .Done();

            Debug.Log("player saved: " + Serializer.ToJsonString(this.player));
            
        }

        // void OnDisable()
        // {
        //     this.SavePlayer();
        // }

        public void LoadPlayer()
        {
            Debug.Log("Loading player data...");

            OnFacet<PlayerDataFacet>
                .Call(
                    nameof(PlayerDataFacet.LoadPlayer),
                    PlayerToken.Get(),
                    this.player
                )
                .Then(() => {
                    Debug.Log("Player data was loaded.");
                })
                .Done();
            Debug.Log("loaded data into playerEntity");
            osloData.currentHealth = osloData.startingHealth;
            osloData.startingAvailableOrbs = this.player.startingAvailableOrbs;
            osloData.startingEquippedOrbType = this.player.startingEquippedOrbType;
            // osloData.equippedOrbType = this.player.equippedOrbType;
            // osloData.equippedOrbIndex = this.player.equippedOrbIndex;

            // resetting orbs
            osloOrbs.DestroyEquippedOrb();
            osloData.equippedOrb = null;
            osloData.equippedOrbType = null;
            osloData.availableOrbs = new List<GameObject>();
            SceneManager.LoadScene(this.player.savedSceneIndex);

            if (this.player.startingAvailableOrbs.Count != 0)
            {
                Debug.Log("startingAvailableOrbs not null, recreating orbs: " + Serializer.ToJsonString(this.player.startingAvailableOrbs));
                foreach (string orbName in this.player.startingAvailableOrbs)
                {
                    osloOrbs.SpawnNewOrb(orbName);
                }
                osloData.equippedOrbIndex = 0;
                osloData.equippedOrbType = this.player.startingAvailableOrbs[0];
            }
            // osloData.equippedOrbType = this.player.startingEquippedOrbType;

            Time.timeScale = 1f;
            Debug.Log("player loaded: " + Serializer.ToJsonString(this.player));
            // LoadPlayer();
        }

        void OnPlayerDownloaded(PlayerEntity downloadedPlayer)
        {
            this.player = downloadedPlayer;

            Debug.Log(
                "Player was downloaded: " +
                Serializer.ToJsonString(downloadedPlayer)
            );
        }

        public void LoadSavedScene()
        {

        }
    }
}