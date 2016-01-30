using UnityEngine;
using System.Collections;

public class Player2MovementGrid : MonoBehaviour {

    Vector3 pos;
    public float speed;
    CreateGameboard gameboard;

    // Use this for initialization
    void Start()
    {
        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        pos = transform.position;
        //Debug.Log(gameboard.GetTilePosition(new Vector2(5,5))[0]);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameboard.tileSize);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(-gameboard.tileSize, 0)) != null) 
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(-gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(-gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(gameboard.tileSize, 0)) != null)
        {

            Debug.Log("right");
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(gameboard.tileSize, 0)).tag == "Tile")
            {
                pos += new Vector3(gameboard.tileSize, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(0, gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position == pos && gameboard.GetTileGameObject(transform.position + new Vector3(0, -gameboard.tileSize)) != null)
        {
            if (gameboard.GetTileGameObject((Vector2)transform.position + new Vector2(0, -gameboard.tileSize)).tag == "Tile")
            {
                pos += new Vector3(0, -gameboard.tileSize);
                transform.localEulerAngles = new Vector3(0, 0, 270);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

    }
}