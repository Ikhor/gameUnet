using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerL : NetworkBehaviour
{
    [SyncVar]
    public Color color;
    [SyncVar]
    public string playerName;

    public int playerId;
    
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (playerId != NetworkGameManagerTurn.sInstance.currentTurn)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NetworkGameManagerTurn.sInstance.OnTurnRequest();
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

        if (NetworkGameManager.sInstance != null)
        {//we MAY be awake late (see comment on _wasInit above), so if the instance is already there we init
            Init();
        }
    }

    //hard to control WHEN Init is called (networking make order between object spawning non deterministic)
    //so we call init from multiple location (depending on what between spaceship & manager is created first).
    protected bool _wasInit = false;

    public void Init()
    {
        if (_wasInit)
            return;

       _wasInit = true;
    }
}