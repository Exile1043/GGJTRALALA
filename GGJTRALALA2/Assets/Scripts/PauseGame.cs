using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    public bool gamePaused,
                mute;

    // Use this for initialization
    void Start()
    {
        gamePaused = false;
        mute = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            gamePaused = !gamePaused;
            mute = !mute;
        }



        if (gamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;


        if (mute == true)
        {
            // Add audio listener here.
        }
        else
        {
        }

    }
}
