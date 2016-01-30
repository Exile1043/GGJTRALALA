using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum Player { Player1, Player2 };
    [SerializeField]
    private Player currentPlayer;
    [SerializeField]
    private float shotCounterTotal;
    private float shotCounterCurrent;
    private bool gamePaused = false;
    private float xPosition;

	void Start () {
        shotCounterCurrent = shotCounterTotal;
        currentPlayer = Player.Player1;
        xPosition = 10;
	}

    void Update() {
        


    }

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
            xPosition = 680;
        }
        else
        {
            currentPlayer = Player.Player1;
            xPosition = 10;
        }
        Debug.Log("Player is now: " + currentPlayer);
    }


    void OnGUI()
    {
        GUI.Label(new Rect(xPosition, 10, 20, 20), Mathf.CeilToInt(shotCounterCurrent).ToString());
    }

   
}
