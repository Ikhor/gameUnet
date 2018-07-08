using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(sendInterval = 0.033f)]
public class PlayerControllerL : NetworkBehaviour
{
    [SyncVar]
    public Color color;
    [SyncVar]
    public string playerName;

    public int playerId;
    public NetworkGameManagerTurn ngmt;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if(ngmt == null)
            ngmt = FindObjectOfType<NetworkGameManagerTurn>();

        if (playerId != ngmt.iActivePlayer)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            iActivePlayer = ngmt.iActivePlayer;
            CmdTurnChange();
        }
    }

    void Start()
    {
        GetComponent<Renderer>().material.color = color;
     
        if (color == Color.red)
        {
            playerId = 0;
        }
        else if (color == Color.cyan)
        {
            playerId = 1;
        }
        else if (color == Color.blue)
        {
            playerId = 2;
        }
        else if (color == Color.green)
        {
            playerId = 3;
        }
        else if (color == Color.green)
        {
            playerId = 4;
        }
        else if (color == Color.magenta)
        {
            playerId = 5;
        }

        ngmt = FindObjectOfType<NetworkGameManagerTurn>();
    }

    [SyncVar(hook = "OnTurnChange")]
    public int iActivePlayer = 0;
    public int ActivePlayer
    {
        get
        {
            return iActivePlayer;
        }
    }

    void OnTurnChange(int value)
    {
        ngmt.iActivePlayer = value;
        iActivePlayer = value;
        Debug.Log(value);
    }

    [Command]
    public void CmdTurnChange()
    {
        iActivePlayer = ngmt.iActivePlayer;
        iActivePlayer = (iActivePlayer + 1) % 2;
    }

}