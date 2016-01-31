using UnityEngine;
using System.Collections;

public class Player2MovementGrid : PlayerBehaviour
{
    Vector3 pos;
    public float speed;
    CreateGameboard gameboard;
    GameManager gamemanager;
    GameObject currentTile;
    public int[] startCoord = { 0, 0 };
    public int[] currentCoord = { 0, 0 };
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
        //Debug.Log(gameboard.GetTilePosition(new Vector2(5,5))[0]);
        gamemanager = GameManager.instance;
        usedAction = false;
        shifting = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentCoord[0] = currentCoord[0] % 7;
        currentCoord[1] = currentCoord[1] % 7;
        if(currentCoord[0] < 0)
        {
            currentCoord[0] = 6;
        }
        if (currentCoord[1] < 0)
        {
            currentCoord[1] = 6;
        }
        transform.parent = currentTile.transform;
        transform.position = currentTile.transform.position;
        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        if (!canAct)
            return;

        Debug.Log("Player1 Movement Update Active");
        if (Input.GetKeyDown(KeyCode.RightShift) || shifting == true)
        {
            Debug.Log(shifting);
            shifting = true;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ApplyNewRule();
                gameboard.ShiftTiles(currentCoord, 0);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ApplyNewRule();
                gameboard.ShiftTiles(currentCoord, 1);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ApplyNewRule();
                gameboard.ShiftTiles(currentCoord, 2);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ApplyNewRule();
                gameboard.ShiftTiles(currentCoord, 3);
                usedAction = true;
                shifting = false;
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameboard.GetCoordTile(currentCoord[0] - 1, currentCoord[1]) != null)
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
        else if (Input.GetKeyDown(KeyCode.RightArrow) && gameboard.GetCoordTile(currentCoord[0] + 1, currentCoord[1]) != null)
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
        else if (Input.GetKeyDown(KeyCode.UpArrow) && gameboard.GetCoordTile(currentCoord[0], currentCoord[1] - 1) != null)
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
        else if (Input.GetKeyDown(KeyCode.DownArrow) && gameboard.GetCoordTile(currentCoord[0], currentCoord[1] + 1) != null)
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