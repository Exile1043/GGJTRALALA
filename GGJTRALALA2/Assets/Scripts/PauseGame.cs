using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{ 

    public GUISkin gameSkin;
    public bool IngameMenuShow = false;

    private const int Ingame_Menu_Window_ID = 0;
    private Rect ingameWindowBox = new Rect(Screen.width / 2 - 85, Screen.height / 2 - 200, 250, 400);
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = true;	
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IngameMenuShow = !IngameMenuShow;

        }
    }
    void OnGUI()
    {
        GUI.skin = gameSkin;

        if (IngameMenuShow)
        {
            ingameWindowBox = GUI.Window(Ingame_Menu_Window_ID, ingameWindowBox, IngameMenuDisplay, "");
            Cursor.visible = true;
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }     

    }

    public void IngameMenuDisplay(int Ingame_Menu_Window_ID)
    {
        if (GUI.Button(new Rect(20, 30, 150, 32), "Return", "IngameButton"))
        {
            IngameMenuShow = false;
        }
        if (GUI.Button(new Rect(20, 60, 150, 32), "Options", "IngameButton"))
        {

        }
        if (GUI.Button(new Rect(20, ingameWindowBox.height - 42, 150, 32), "Exit to Main Menu", "IngameButton"))
        {
            SceneManager.LoadScene("MainMenu"); 
        }
    }
}
