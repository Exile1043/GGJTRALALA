﻿using UnityEngine;
using System.Collections;

public class CantEnter : TileRule
{

    GameObject[] players;
    [SerializeField]
    private GameManager.Player ForbiddenPlayer;
    private GameManager.Player Player1 = GameManager.Player.Player1;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ApplyRule()
    {
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        foreach (GameObject player in players)
        {
            if (player.transform.position == this.transform.position && player.GetComponent<PlayerBehaviour>().ReturnPlayer() == ForbiddenPlayer)
            {
                
                if (player.GetComponent<PlayerBehaviour>().ReturnPlayer() == Player1)
                {
                    //player.GetComponent<PlayerMovementGrid>().pos = player.GetComponent<PlayerMovementGrid>().startingPos;
                    //player.transform.position = player.GetComponent<PlayerMovementGrid>().startingPos;
                }
                else
                {
                    //Player2MovementGrid playerMoveComponent = GetComponent<Player2MovementGrid>();
                    //playerMoveComponent.pos = playerMoveComponent.startingPos;
                    //player.transform.position = playerMoveComponent.startingPos;
                }
                
            }
        }
    }
}
