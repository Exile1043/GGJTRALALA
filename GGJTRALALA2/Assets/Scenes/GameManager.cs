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

	void Start () {
        shotCounterCurrent = shotCounterTotal;
        currentPlayer = Player.Player1;
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
        }
        else
            currentPlayer = Player.Player1;

        Debug.Log("Player is now: " + currentPlayer);
    }
}
