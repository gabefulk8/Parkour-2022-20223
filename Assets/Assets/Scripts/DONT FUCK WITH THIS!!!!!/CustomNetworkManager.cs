using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using Steamworks;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private PlayerObjectController GamePlayerPrefab;
    GameObject playerSpawnPrefab;

    public List<PlayerObjectController> GamePlayers { get; } = new List<PlayerObjectController>();

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if (conn.connectionId == 0)
        {
            playerSpawnPrefab = spawnPrefabs[0];
        }

        if (conn.connectionId == 1)
        {
            playerSpawnPrefab = spawnPrefabs[1];
        }

        if (playerSpawnPrefab != null)
        {
            Debug.Log("player list item created");
            PlayerObjectController GamePlayerInstance = Instantiate(playerSpawnPrefab.GetComponent<PlayerObjectController>());

            GamePlayerInstance.connectionID = conn.connectionId;
            GamePlayerInstance.playerIDNumber = GamePlayers.Count + 1;
            GamePlayerInstance.playerSteamID = (ulong)SteamMatchmaking.GetLobbyMemberByIndex((CSteamID)SteamLobby.Instance.CurrentLobbyID, GamePlayers.Count);

            NetworkServer.AddPlayerForConnection(conn, GamePlayerInstance.gameObject);
        }
    }

    public void StartGame(string SceneName)
    {
        ServerChangeScene(SceneName);
    }
    
    public void EndGame()
    {
        ServerChangeScene("EndScreen");
    }
}
