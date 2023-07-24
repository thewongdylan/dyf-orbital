// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using Unisave.Facets;
// using Unisave.Facades;
// using Unisave.Serialization;

// public class SaveFunctions : MonoBehaviour
// {
//     [SerializeField] private OsloData osloData;
//     private PlayerDataClient playerDataClient;

//     [SerializeField] private PlayerEntity playerEntity;
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         playerDataClient = GetComponent<PlayerDataClient>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void Save()
//     {
//         Debug.Log("SaveFunctions: saving player");
//         playerDataClient.SavePlayer();
//         Debug.Log("SaveFunctions: saved player");
//     }

//     public void Load()
//     {
//         Debug.Log("SaveFunctions: loading player"); 
//         playerDataClient.LoadPlayer();
//         osloData.currentHealth = playerEntity.currentHealth;
//         osloData.equippedOrbType = playerEntity.equippedOrbType;
//         osloData.equippedOrbIndex = playerEntity.equippedOrbIndex;
//         osloData.lastSceneIndex = playerEntity.lastSceneIndex;
//         SceneManager.LoadScene(osloData.lastSceneIndex);
//         Debug.Log("SaveFunctions: loaded player");
//     }

// }
