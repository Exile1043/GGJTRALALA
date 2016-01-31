using UnityEngine;
using System.Collections;

public class CreateGameboard : MonoBehaviour {
    public GameObject[] tiles;
    public int gridSize;
    public float tileSize = 0;

    GameObject[][] gameBoardGrid;



    // Use this for initialization
    void Start() {
        //get width of tile
        tileSize = tiles[0].GetComponent<Renderer>().bounds.size.x;
        Create();
        GetGrid();

    }

    // Update is called once per frame
    void Update() {

    }

    void Create()
    {
        //create jagged array of gridSize*gridSize
        gameBoardGrid = new GameObject[gridSize][];

        for (int i = 0; i < gridSize; i++)
        {
            gameBoardGrid[i] = new GameObject[gridSize];
        }

    }

    void GetGrid()
    {
        Renderer[] tileRenderers = GetComponentsInChildren<Renderer>();

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                gameBoardGrid[i][j] = tileRenderers[i * gridSize + j].gameObject;

            }
        }

    }

    void Fill()
    {

        GameObject currentTile;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                currentTile = (GameObject)Instantiate(tiles[0], transform.position + new Vector3(tileSize * (-gridSize / 2) + tileSize * x, -(tileSize * (-gridSize / 2) + tileSize * y), 0), Quaternion.identity);
                currentTile.transform.parent = gameObject.transform;
            }
        }
    }

    public void ShiftTiles(int[] playerCoords, int playerDirection)
    {
        GameObject temp = null;
        switch (playerDirection)
        {
            case 0:
                //up
                for (int i = 0; i < gridSize; i++)
                {
                    if (i == 0)
                    {
                        temp = gameBoardGrid[playerCoords[0]][i];
                    }
                    else
                    {
                        gameBoardGrid[playerCoords[0]][i - 1] = gameBoardGrid[playerCoords[0]][i];
                        gameBoardGrid[playerCoords[0]][i].transform.position += new Vector3(0, tileSize);
                        if (gameBoardGrid[playerCoords[0]][i].transform.Find("Player 1") != null)
                        {
                            gameBoardGrid[playerCoords[0]][i].transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[1]--;
                        }
                        if (gameBoardGrid[playerCoords[0]][i].transform.Find("Player 2") != null)
                        {
                            gameBoardGrid[playerCoords[0]][i].transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[1]--;
                        }
                    }
                }
                temp.transform.position -= new Vector3(0, tileSize * (gridSize - 1));
                if (temp.transform.Find("Player 1") != null)
                {
                    temp.transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[1]--;
                }
                if (temp.transform.Find("Player 2") != null)
                {
                    temp.transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[1]--;
                }
                gameBoardGrid[playerCoords[0]][gridSize - 1] = temp;
                break;
            case 1:
                //left
                for (int i = 0; i < gridSize; i++)
                {
                    if (i == 0)
                    {
                        temp = gameBoardGrid[i][playerCoords[1]];
                        Debug.Log(playerCoords[1]);
                    }
                    else
                    {
                        gameBoardGrid[i - 1][playerCoords[1]] = gameBoardGrid[i][playerCoords[1]];
                        gameBoardGrid[i][playerCoords[1]].transform.position -= new Vector3(tileSize, 0);
                        if (gameBoardGrid[i][playerCoords[1]].transform.Find("Player 1") != null)
                        {
                            gameBoardGrid[i][playerCoords[1]].transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[0]--;
                        }
                        if (gameBoardGrid[i][playerCoords[1]].transform.Find("Player 2") != null)
                        {
                            gameBoardGrid[i][playerCoords[1]].transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[0]--;
                        }
                    }
                }
                temp.transform.position += new Vector3(tileSize * (gridSize - 1), 0);
                if (temp.transform.Find("Player 1") != null)
                {
                    temp.transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[0]--;
                }
                if (temp.transform.Find("Player 2") != null)
                {
                    temp.transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[0]--;
                }
                gameBoardGrid[gridSize - 1][playerCoords[1]] = temp;
                break;
            case 2:
                //right
                for (int i = gridSize - 1; i >= 0; i--)
                {
                    if (i == gridSize - 1)
                    {
                        temp = gameBoardGrid[i][playerCoords[1]];
                    }
                    else
                    {
                        gameBoardGrid[i + 1][playerCoords[1]] = gameBoardGrid[i][playerCoords[1]];
                        if (gameBoardGrid[i][playerCoords[1]].transform.Find("Player 1") != null)
                        {
                            gameBoardGrid[i][playerCoords[1]].transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[0]++;
                        }
                        if (gameBoardGrid[i][playerCoords[1]].transform.Find("Player 2") != null)
                        {
                            gameBoardGrid[i][playerCoords[1]].transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[0]++;
                        }
                        gameBoardGrid[i][playerCoords[1]].transform.position += new Vector3(tileSize, 0);
                    }
                }
                temp.transform.position -= new Vector3(tileSize * (gridSize - 1), 0);
                if (temp.transform.Find("Player 1") != null)
                {
                    temp.transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[0]++;
                }
                if (temp.transform.Find("Player 2") != null)
                {
                    temp.transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[0]++;
                }
                gameBoardGrid[0][playerCoords[1]] = temp;
                break;
            case 3:
                //down
                for (int i = gridSize -1; i >= 0; i--)
                {
                    if (i == gridSize - 1)
                    {
                        temp = gameBoardGrid[playerCoords[0]][i];
                    }
                    else
                    {
                        gameBoardGrid[playerCoords[0]][i + 1] = gameBoardGrid[playerCoords[0]][i];
                        if (gameBoardGrid[playerCoords[0]][i].transform.Find("Player 1") != null)
                        {
                            gameBoardGrid[playerCoords[0]][i].transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[1]++;
                        }
                        if (gameBoardGrid[playerCoords[0]][i].transform.Find("Player 2") != null)
                        {
                            gameBoardGrid[playerCoords[0]][i].transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[1]++;
                        }
                        gameBoardGrid[playerCoords[0]][i].transform.position -= new Vector3(0, tileSize);
                    }
                }
                temp.transform.position += new Vector3(0, tileSize * (gridSize - 1), 0);
                if (temp.transform.Find("Player 1") != null)
                {
                    temp.transform.GetComponentInChildren<PlayerMovementGrid>().currentCoord[1]++;
                }
                if (temp.transform.Find("Player 2") != null)
                {
                    temp.transform.GetComponentInChildren<Player2MovementGrid>().currentCoord[1]++;
                }
                gameBoardGrid[playerCoords[0]][0] = temp;
                break;
            default:
                Debug.Log("Direction needs to be an int 0-3");
                break;
        }
    }
    public GameObject GetCoordTile(int x, int y)
    {
        GameObject Tile;
        try {
            Tile = gameBoardGrid[x][y];
        }
        catch
        {
            Tile = null;
        }
        return Tile;
    }

    public int[] GetTileCoords(GameObject Tile)
    {
        int[] temp = { 0, 0 };
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if(Tile = gameBoardGrid[i][j])
                {
                    temp[0] = i;
                    temp[1] = j;
                }
            }
        }
        return temp;
    }

    /*public int[] GetTilePosition(Vector2 position)
    {
        int[] tileCoord = { 0, 0 };
        tileCoord[0] = (int)(Mathf.Round(position.x / tileSize) + gridSize / 2);
        tileCoord[1] = -(int)(Mathf.Round(position.y / tileSize) - gridSize / 2);
        return tileCoord;
    }*/

    /*public GameObject GetTileGameObject(Vector2 position)
    {
        try {
            return gameBoardGrid[GetTilePosition(position)[0]][GetTilePosition(position)[1]];
        }
        catch
        {
            return null;
        }
    }*/
}
