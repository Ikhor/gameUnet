using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkGameManagerTurn : NetworkBehaviour
{

    static public NetworkGameManagerTurn sInstance = null;


    void Awake()
    {
        sInstance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SyncVar(hook = "OnTurnChanged")]
    public int currentTurn = 0;

    public void OnTurnChanged(int value)
    {
        Debug.Log("New Turn");
        currentTurn = value;
    }

    public void OnTurnRequest()
    {
        CmdTurnChange();
    }

    [Command]
    public void CmdTurnChange()
    {
        currentTurn++;
        currentTurn %= 2;
    }

}
