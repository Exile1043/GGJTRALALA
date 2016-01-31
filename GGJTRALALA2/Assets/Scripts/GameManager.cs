using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{
    public enum Player { Player1, Player2 };
    [SerializeField]
    private Player currentPlayer;
    [SerializeField]
    private float shotCounterTotal = 10.0f;
    private float shotCounterCurrent;
    private bool gamePaused = false;
    private float xPosition;

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private RandomGem randomGemScript;                      //Store a reference to our BoardManager which will set up the level.
    private int level = 3;                                  //Current level number, expressed in game as "Day 1".
    public int inventoryP1 = 0;
    public int inventoryP2 = 0;
    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public string[] tileRuleQueue = { "\n onlyBlue", "\n onlyGreen", "\n arrow", "\n withImpl", "\n withoutImp" };
    private string currentRule;

    public PlayerBehaviour player1;
    public PlayerBehaviour player2;

    //Awake is always called before any Start functions
    void Awake()
    {
        //initializes the shot counter variables and position
        shotCounterCurrent = shotCounterTotal;
        currentPlayer = Player.Player1;
        xPosition = 10;

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        randomGemScript = GetComponent<RandomGem>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        //randomGemScript.SetupScene(level);

        //Call the shuffleQueue method to shuffle the tilerule list.
        shuffleQueue();
    }



    //Update is called every frame.
    void Update()
    {

    }

    //FixedUpdate used to keep the time
    void FixedUpdate()
    {
        if (!gamePaused)
        {
            if (shotCounterCurrent > 0.0f)
            {
                shotCounterCurrent = shotCounterCurrent - 1.0f * Time.fixedDeltaTime;
            }

            if (shotCounterCurrent <= 0.0f)
            {
                Debug.Log("Counter done.");
                SwitchPlayer();
                shotCounterCurrent = shotCounterTotal;
            }
        }
    }

    private void SwitchPlayer()
    {
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
            Debug.Log("Player2 can act: " + player2.toggleCanAct(true));
            player1.toggleCanAct();
            xPosition = Screen.width - 40;
        }
        else if (currentPlayer == Player.Player2)
        {
            currentPlayer = Player.Player1;
            Debug.Log("Player1 can act: " + player1.toggleCanAct(true));
            player2.toggleCanAct();
            xPosition = 15;
        }
        Debug.Log("Player is now: " + currentPlayer);
    }

    public void shuffleQueue()
    {
        // Knuth algorithm, http://algs4.cs.princeton.edu/11model/Knuth.java.html
        for (int t = 0; t < tileRuleQueue.Length; t++)
        {
            string tmp = tileRuleQueue[t];
            int r = Random.Range(t, tileRuleQueue.Length);
            tileRuleQueue[t] = tileRuleQueue[r];
            tileRuleQueue[r] = tmp;
        }
    }

    public string ReturnTileRule()
    {
        return currentRule;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(xPosition, 10, 200, 200), "<size=30>" + Mathf.CeilToInt(shotCounterCurrent).ToString() + "</size>");
        GUI.Label(new Rect(15, Screen.height / 2, 250, 250), "<size=20>Player 1 Inventory: " + Mathf.CeilToInt(inventoryP1).ToString() + " / 3</size>");
        GUI.Label(new Rect(15, Screen.height / 2 + 20, 250, 250), "<size=20>Player 1 Score: " + Mathf.CeilToInt(scoreP1).ToString() + " / 3</size>");
        GUI.Label(new Rect(Screen.width - 230, Screen.height / 2, 250, 250), "<size=20>Player 2 Inventory: " + Mathf.CeilToInt(inventoryP2).ToString() + " / 3</size>");
        GUI.Label(new Rect(Screen.width - 230, Screen.height / 2 + 20, 250, 250), "<size=20>Player 2 Score: " + Mathf.CeilToInt(scoreP2).ToString() + " / 3</size>");


        for (int i = 0; i < tileRuleQueue.Length; i++)
        {
            GUI.Label(new Rect(Screen.width - 230, (10 * i), 250, 250), tileRuleQueue[i]);
        }
    }

    public Player ReturnPlayer()
    {
        return currentPlayer;
    }

    public void EndTurn()
    {
        SwitchPlayer();
        shotCounterCurrent = shotCounterTotal;
    }
}
