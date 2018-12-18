using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbGamerz = 0;
    public enum NetworkStatus
    {
        None,
        Server,
        Client
    }
    public DatabaseManager databaseManager;
    public NetworkStatus status;
    public GameObject UI_Connection_Client;
	// Use this for initialization
	void Start ()
    {
        if (status == NetworkStatus.Server)
        {
            GameObject g = new GameObject("Server");
            g.AddComponent<Server>();
        }
        else if (status == NetworkStatus.Client)
        {
            GameObject g = new GameObject("Client");
            Client client = g.AddComponent<Client>();
           
            UI_Connection_Client.SetActive(true);
            client.Init();
        }

    }
	

	// Update is called once per frame
	void Update ()
    {
		
	}
    
}
