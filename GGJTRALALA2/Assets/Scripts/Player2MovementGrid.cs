using UnityEngine;
using System.Collections;

public class Player2MovementGrid : PlayerBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.parent = currentTile.transform;
        transform.position = currentTile.transform.position;
        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        if (!canAct)
            return;

        Debug.Log("Player1 Movement Update Active");
        if (Input.GetKeyDown(KeyCode.LeftShift) || shifting == true)
        {
            Debug.Log(shifting);
            shifting = true;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameboard.ShiftTiles(currentCoord, 0);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameboard.ShiftTiles(currentCoord, 1);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameboard.ShiftTiles(currentCoord, 2);
                usedAction = true;
                shifting = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
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