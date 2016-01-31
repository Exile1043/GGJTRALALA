using UnityEngine;
using System.Collections;

public class GemSpawner : MonoBehaviour {
    GameManager gamemanager;
    CreateGameboard gameboard;
    public GameObject gem;
    public int gemAmount;


    // Use this for initialization
    void Start () {
        gamemanager = GameManager.instance;
        gameboard = GameObject.Find("Gameboard").GetComponent<CreateGameboard>();
        PlaceRandomPosition();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlaceRandomPosition()
    {
        GameObject currentGem;
        GameObject currentTile;
        bool placed;
        int x,y;
        for (int i = 0; i < gemAmount; i++)
        {
            placed = false;
            x = Random.Range(0, gameboard.gridSize);
            y = Random.Range(0, gameboard.gridSize);

            currentGem = (GameObject)Instantiate(gem, new Vector3(x * gameboard.tileSize - 3 * gameboard.tileSize, y * gameboard.tileSize - 3 * gameboard.tileSize), Quaternion.identity);
            /*while(!placed)
            {
                currentTile = gameboard.GetTileGameObject(new Vector2(0,0));
                Debug.Log(gameboard);
                if (currentTile)
                {
                    if (currentTile.tag == "Tile" && currentTile.transform.childCount == 0)
                    {
                        currentGem.transform.parent = currentTile.transform;
                        placed = true;
                    }
                }
                else
                {
                    x = Random.Range(0, gameboard.gridSize);
                    y = Random.Range(0, gameboard.gridSize);

                    currentTile.transform.position = new Vector2(x, y);
                }
            }*/
        }
    }
}
