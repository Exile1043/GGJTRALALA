using UnityEngine;
using System.Collections;

public class PlayerMovementGrid : PlayerBehaviour
{

    public Vector3 pos, startingPos;
    public float speed;
    CreateGameboard gameboard;
    GameManager gamemanager;
    GameObject currentTile;
    public int[] startCoord = { 0, 0 };
    int[] currentCoord = { 0, 0 };
    bool usedAction;
    bool shifting;

    // Use this for initialization
    void Start()
    {
        base.Start();

        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        currentCoord = startCoord;
        currentTile = gameboard.GetCoordTile(currentCoord[0], currentCoord[1]);
        transform.parent = currentTile.transform;
        startingPos = transform.position;
        //Debug.Log(gameboard.GetTilePosition(new Vector2(5,5))[0]);
        gamemanager = GameManager.instance;
        usedAction = false;
        shifting = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent = currentTile.transform;
        transform.position = currentTile.transform.position;
        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        if (!canAct)
            return;

        Debug.Log("Player1 Movement Update Active");
        if (Input.GetKeyDown(KeyCode.Space) || shifting == true)
        {
            Debug.Log(shifting);
            shifting = true;
            if (Input.GetKeyDown(KeyCode.W))
            {
                gameboard.ShiftTiles(currentCoord, 0);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                gameboard.ShiftTiles(currentCoord, 1);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                gameboard.ShiftTiles(currentCoord, 2);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                gameboard.ShiftTiles(currentCoord, 3);
                usedAction = true;
                shifting = false;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) && gameboard.GetCoordTile(currentCoord[0] - 1, currentCoord[1]) != null)
        {
            if (gameboard.GetCoordTile(currentCoord[0] - 1, currentCoord[1]).tag == "Tile")
            {
                currentTile = gameboard.GetCoordTile(currentCoord[0] - 1, currentCoord[1]);
                currentCoord[0]--;
                transform.localEulerAngles = new Vector3(0, 0, 180);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && gameboard.GetCoordTile(currentCoord[0] + 1, currentCoord[1]) != null)
        {
            if (gameboard.GetCoordTile(currentCoord[0] + 1, currentCoord[1]).tag == "Tile")
            {
                currentTile = gameboard.GetCoordTile(currentCoord[0] + 1, currentCoord[1]);
                currentCoord[0]++;
                transform.localEulerAngles = new Vector3(0, 0, 0);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && gameboard.GetCoordTile(currentCoord[0], currentCoord[1] - 1) != null)
        {
            Debug.Log("W pressed");
            if (gameboard.GetCoordTile(currentCoord[0], currentCoord[1] - 1).tag == "Tile")
            {
                currentTile = gameboard.GetCoordTile(currentCoord[0], currentCoord[1] - 1);
                currentCoord[1]--;
                transform.localEulerAngles = new Vector3(0, 0, 90);
                usedAction = true;
                playWalkSound();
                transform.position = pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) && gameboard.GetCoordTile(currentCoord[0], currentCoord[1] + 1) != null)
        {
            if (gameboard.GetCoordTile(currentCoord[0], currentCoord[1] + 1).tag == "Tile")
            {
                currentTile = gameboard.GetCoordTile(currentCoord[0], currentCoord[1] + 1);
                currentCoord[1]++;
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