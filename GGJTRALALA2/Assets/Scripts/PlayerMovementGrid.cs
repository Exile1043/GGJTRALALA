﻿using UnityEngine;
using System.Collections;

public class PlayerMovementGrid : PlayerBehaviour
{

    Vector3 pos;
    public float speed;
    CreateGameboard gameboard;
    GameManager gamemanager;
    bool usedAction;

    // Use this for initialization
    void Start()
    {
        base.Start();

        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        pos = transform.position;
        //Debug.Log(gameboard.GetTilePosition(new Vector2(5,5))[0]);
        gamemanager = GameManager.instance;
        usedAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAct)
            return;
        Debug.Log("test");
        if (Input.GetKeyDown(KeyCode.A) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(-gameboard.tileSize, 0)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(-gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(-gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 180);
                usedAction = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(gameboard.tileSize, 0)) != null)
        {

            Debug.Log("right");
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
                usedAction = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(0, gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 90);
                usedAction = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(0, -gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, -gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, -gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 270);
                usedAction = true;
            }
        }

        if (usedAction)
        {
            //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
            transform.position = pos;
            gamemanager.EndTurn();
            usedAction = false;
        }

    }
}
