using UnityEngine;
using System.Collections;

public class CreateGameboard : MonoBehaviour {
    public GameObject[] tiles;
    public int gridSize;
    float tileSize = 0;

    GameObject[][] gameBoardGrid;



    // Use this for initialization
    void Start () {
        //create jagged array and set column size 
        gameBoardGrid = new GameObject[gridSize][];
        //get width of tile
        tileSize = tiles[0].GetComponent<Renderer>().bounds.size.x;
        Create();
        GetGrid();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Create ()
    {
        GameObject currentTile;

        for (int i = 0; i < gridSize; i++)
        {
            gameBoardGrid[i] = new GameObject[gridSize];
        }


        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                currentTile = (GameObject)Instantiate(tiles[0], transform.position + new Vector3(tileSize * (-gridSize / 2) + tileSize * x, -(tileSize * (-gridSize / 2) + tileSize * y), 0), Quaternion.identity);
                currentTile.transform.parent = gameObject.transform;
            }
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

    void ShiftTiles(Vector3 playerPosition, int playerDirection)
    {
        
    }

   /* public Vector3 GetTilePosition()
    {
        Vector3 tilePosition 
        return GetTilePosition;
    }*/
}
