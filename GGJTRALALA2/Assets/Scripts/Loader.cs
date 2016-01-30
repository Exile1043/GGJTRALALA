using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    public string levelName;

	// Use this for initialization
	public void Play () {
        if(levelName != "Exit")
        {
            SceneManager.LoadScene(levelName);
        } else
        {
            Application.Quit();
        }
	}
}
