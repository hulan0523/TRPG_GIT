using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class network_Manager : MonoBehaviour {
    private const string typeName = "UniqueGameName";
    private const string gameName = "RoomName";
    private HostData[] hostList;

    public GameObject playerPrefab;

    private void RefreshHostList()
    {
        MasterServer.RequestHostList(typeName);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.HostListReceived)
            hostList = MasterServer.PollHostList();
    }
    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        Network.Instantiate(playerPrefab, new Vector3(0f, -0.27f, 0f), Quaternion.identity, 0);
    }
    private void StartServer()
    {
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }
    void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
    }
    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(0, 0, 50, 50), "Start Server"))
                StartServer();

            if (GUI.Button(new Rect(100, 0, 50, 50), "Refresh Hosts"))
                RefreshHostList();

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(0, 100 + (110 * i), 50, 50), hostList[i].gameName))
                        JoinServer(hostList[i]);
                }
            }
        }
    }
}
