using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Steamworks;
using UnityEngine.UI;

public class SteamLobby : MonoBehaviour
{
    public static SteamLobby instance;

    protected Callback<LobbyCreated_t> lobbyCreated;
    protected Callback<GameLobbyJoinRequested_t> joinRequest;
    protected Callback<LobbyEnter_t> lobbyEnter;

    public ulong currentLobbyID;
    private const string HostAddressKey = "HostAddress";
    private CustomNetworkManager nManager;


    private void Start()
    {
        if(!SteamManager.Initialized) { return; }
        if(instance == null) { instance = this; }

        nManager = GetComponent<CustomNetworkManager>();

        lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        joinRequest = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequest);
        lobbyEnter = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
    }

    public void HostLobby()
    {
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, nManager.maxConnections);
    }

    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        if(callback.m_eResult != EResult.k_EResultOK) { return; }

        Debug.Log("Lobby Created Succesfull");

        nManager.StartHost();

        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddressKey, SteamUser.GetSteamID().ToString());
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name", SteamFriends.GetPersonaName().ToString() + "'s Lobby");
    }

    private void OnJoinRequest(GameLobbyJoinRequested_t callback)
    {
        Debug.Log("request to join lobby");

        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
    }

    private void OnLobbyEntered(LobbyEnter_t callback)
    {
        //Everyone
        currentLobbyID = callback.m_ulSteamIDLobby;

        //Clients
        if (NetworkServer.active) { return; }

        nManager.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddressKey);

        nManager.StartClient();

    }

}
