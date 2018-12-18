using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System;
using UnityEngine.UI;
public class Client : MonoBehaviour
{

    public Text text;
    public Toggle toggle;

    public Button buttonConnect;
    public TcpClient client;
    public int port = 11000;

    public bool initialised;
    public bool connected;
    public const int bufferSize = 1024;

    public string name;
    public string password;

    // Use this for initialization
    public void Init ()
    {
        client = new TcpClient();
        text = GameObject.FindGameObjectWithTag("IP_INPUT").transform.Find("Text").GetComponent<Text>();
        toggle = GameObject.FindGameObjectWithTag("TOGGLE_CONNECTION").GetComponent<Toggle>();
        buttonConnect = GameObject.FindGameObjectWithTag("BUTTON_CONNECT").GetComponent<Button>();
        buttonConnect.onClick.AddListener(TryToConnect);
        initialised = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (initialised)
        {
            if (toggle.isOn == false && connected == true)
            {
                toggle.isOn = true;
            }
        }
	}

    public void TryToConnect()
    {

        IPAddress ipaddress = IPAddress.Parse(text.text);
        client.BeginConnect(ipaddress, port, EndConnect, client);

    }

    public void EndConnect(IAsyncResult result)
    {
        client.EndConnect(result);
        connected = true;
       
    }
}
