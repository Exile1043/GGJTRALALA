using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameManager.Player thisPlayer;

    protected CreateGameboard gameboard;    
    protected GameObject currentTile;
    protected TileContents currentTileContents;
    protected GameManager gamemanager;

    public Vector3 pos;
    public float speed;

    public int[] startCoord = { 0, 0 };
    public int[] currentCoord = { 0, 0 };

    protected bool canAct = false;
    protected bool usedAction;
    protected bool shifting;

    public List<AudioClip> WalkSoundList;

    void Awake()
    {
        
    }

	protected virtual void Start () {
        if (GameManager.instance.ReturnPlayer() == thisPlayer)
        {
            Debug.Log("Firstplayer: " + thisPlayer);
            canAct = true;
        }
        else
            Debug.Log(GameManager.instance.ReturnPlayer());

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
	void Update () {
	
	}

    public bool toggleCanAct(bool setTrue = false)
    {
        if(setTrue)
        {
            canAct = true;
            return canAct;
        }
        canAct = !canAct;
        return canAct;
    }

    public void paused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canAct = false;
            Time.timeScale = 0f;
        }
    }


    public void playWalkSound()
    {
        int ranNum = Mathf.FloorToInt(Random.Range(1, 4));
        AudioSource.PlayClipAtPoint(WalkSoundList[ranNum], transform.position);
    }

    public GameManager.Player ReturnPlayer()
    {
        return thisPlayer;
    }

    protected void CheckTileGem()
    {
        getTileContentsScript();
        if (currentTileContents.ReturnGem() != null)
        {
            //Do pick up gem.
        }
    }

    protected void ApplyNewRule()
    {
        getTileContentsScript();
        string newRule = gamemanager.ReturnTileRule();
        switch (newRule)
        {
            case "\n arrow":
                currentTileContents.SetRule(new Direction(), "Direction");
                Debug.Log("Direction added to tile");
                break;
            case "\n onlyBlue":
                currentTileContents.SetRule(new OnlyBlue(), "OnlyBlue");
                Debug.Log("Only Blue added to tile");
                break;
            case "\n onlyGreen":
                currentTileContents.SetRule(new OnlyGreen(), "OnlyGreen");
                Debug.Log("Only Green added to tile");
                break;
            case "\n withImpl":
                currentTileContents.SetRule(new OnlyImplement(), "OnlyImplement");
                Debug.Log("Only Implement added to tile");
                break;
            case "\n withoutImp":
                currentTileContents.SetRule(new NoImplement(), "NoImplement");
                Debug.Log("No Implement added to tile");
                break;
            default:
                Debug.Log("No Rule Returned.");
                break;
        }
           // if(currentTileContents != null)
    }

    protected void CheckTileRule()
    {
        getTileContentsScript();
        if (currentTileContents.ReturnRule() != null)
        {
            currentTileContents.ReturnRule().ApplyRule(this);
            currentTileContents.ClearRule();
        }
    }

    protected void CheckTileRuleOnExit()
    {
        getTileContentsScript();
        if (currentTileContents.ReturnRule() != null)
        {
            currentTileContents.ReturnRule().ApplyRule(this);
            currentTileContents.ClearRule();
        }
    }

    private void getTileContentsScript()
    {
        currentTileContents = currentTile.GetComponent<TileContents>();
    }
}
