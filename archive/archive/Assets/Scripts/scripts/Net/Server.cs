using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System;

public class Server : MonoBehaviour
{
    #region members
        int nbClientConnected;
        public TcpListener server;
        public int port=11000;
        public NetworkStream stream;
        public const int bufferSize = 1024;
        public List<TcpClient> list_client;
    #endregion

    #region enum
        public enum State
        {
            Initialising,
            WaitingforEnoughConnections,
            Running
        }
    #endregion
        public struct NetworkState
        {
            public byte[] readbuffer;
        }


	
	    void Start ()
        {
            list_client = new List<TcpClient>();
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            server.BeginAcceptTcpClient(EndAccept, server);
        }
	
	    void Update ()
        {
		    
	    }

    #region network_callback

        public void EndAccept( IAsyncResult result)
        {

            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)result.AsyncState;
            // End the operation and display the received data on 
            // the console.
            TcpClient client = listener.EndAcceptTcpClient(result);
            list_client.Add(client);
            nbClientConnected ++;
            Debug.Log("Client connected: " + nbClientConnected);
            listener.BeginAcceptTcpClient(EndAccept, server);
        }

    #endregion
}
