using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private GameManager.Player thisPlayer;
    private bool canAct;

	// Use this for initialization
	void Start () {
        if (GameManager.instance.ReturnPlayer() == thisPlayer)
            canAct = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
