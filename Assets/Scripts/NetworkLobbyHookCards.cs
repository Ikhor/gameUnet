using UnityEngine;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class NetworkLobbyHookCards : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PlayerControllerL pcl = gamePlayer.GetComponent<PlayerControllerL>();
        pcl.color = lobby.playerColor;
        pcl.name = lobby.name;
    }
}

