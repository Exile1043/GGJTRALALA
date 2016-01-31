using UnityEngine;
using System.Collections;

public class Player2MovementGrid : PlayerBehaviour
{

    Vector3 pos;
    public float speed;
    CreateGameboard gameboard;
    GameManager gamemanager;
    GameObject currentTile;
    bool usedAction;
    bool shifting;

    // Use this for initialization
    void Start()
    {
        base.Start();

        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        currentTile = gameboard.GetTileGameObject(transform.position);
        transform.parent = currentTile.transform;
        pos = transform.position;
        //Debug.Log(gameboard.GetTilePosition(new Vector2(5,5))[0]);
        gamemanager = GameManager.instance;
        usedAction = false;
        shifting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTile = gameboard.GetTileGameObject(transform.position);
        transform.parent = currentTile.transform;
        if (!canAct)
            return;

        Debug.Log("Player2 Movement Update Active");

        if (Input.GetKeyDown(KeyCode.RightShift) || shifting == true)
        {
            Debug.Log(shifting);
            shifting = true;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameboard.ShiftTiles(transform.position, 0);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameboard.ShiftTiles(transform.position, 1);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameboard.ShiftTiles(transform.position, 2);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameboard.ShiftTiles(transform.position, 3);
                usedAction = true;
                shifting = false;
            }
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameboard.GetTileGameObject(transform.position + new Vector3(-gameboard.tileSize, 0)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(-gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(-gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 180);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gameboard.GetTileGameObject(transform.position + new Vector3(gameboard.tileSize, 0)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameboard.GetTileGameObject(transform.position + new Vector3(0, gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 90);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gameboard.GetTileGameObject(transform.position + new Vector3(0, -gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, -gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, -gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 270);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }

        if (usedAction)
        {
            //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

            gamemanager.EndTurn();
            usedAction = false;
        }

    }
}