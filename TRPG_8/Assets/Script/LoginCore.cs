using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;


public class LoginCore : MonoBehaviour {

    public string serverAddress = "192.168.42.97";
    public int serverPort = 32211;

    private TcpClient _client;
    private NetworkStream _stream;
    private Thread _thread;

    private byte[] _buffer = new byte[1024];
    private string receiveMsg = "";
    private bool isConnected = false;

    //public GameObject player;
    public GameObject playerPrefab;

    void Start()
    {
        //playerPrefab = GameObject.Find("player1");
        //player = GameObject.Find("player1");
        //player.transform.position = new Vector3(-1f, -0.27f, 0f);
        //Instantiate(player, new Vector3(-1f, -0.27f, 0f),Quaternion.identity);
        serverAddress = "192.168.42.97";
        SetupConnection();
    }

    void OnApplicationQuit()
    {
        CloseConnection();
    }

    private void SetupConnection()
    {
        try
        {
            _thread = new Thread(ReceiveData);
            _thread.IsBackground = true;
            _client = new TcpClient(serverAddress, serverPort);
            _stream = _client.GetStream();
            _thread.Start();
            SpawnPlayer();
            isConnected = true;
        }
        catch (Exception e)
        {
            CloseConnection();
            Debug.Log(e.ToString());
        }
    }

    private void SpawnPlayer()
    {
        //Network.Instantiate(playerPrefab, new Vector3(0f, 0.25f, 0f), Quaternion.identity, 0);
        Network.Instantiate(playerPrefab, new Vector3(0f, -0.27f, 0f), Quaternion.identity,1);
    }

    private void ReceiveData()
    {
        if (!isConnected)
            return;

        int numberOfBytesRead = 0;
        while (isConnected && _stream.CanRead)
        {
            try
            {
                numberOfBytesRead = _stream.Read(_buffer, 0, _buffer.Length);
                receiveMsg = Encoding.ASCII.GetString(_buffer, 0, numberOfBytesRead);
                _stream.Flush();
                Debug.Log(receiveMsg);
                receiveMsg = "";
            }
            catch (Exception e)
            {
                CloseConnection();
                Debug.Log(e.ToString());
            }
        }
    }

    private void CloseConnection()
    {
        if (isConnected)
        {
            _thread.Interrupt();
            _stream.Close();
            _client.Close();
            isConnected = false;
            receiveMsg = "";
        }
    }
}
