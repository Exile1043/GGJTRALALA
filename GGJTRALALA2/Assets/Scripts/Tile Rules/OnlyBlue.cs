using UnityEngine;
using System.Collections;

public class OnlyBlue : TileRule {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void ApplyRule(GameManager.Player targetPlayer)
    {
        if (targetPlayer == GameManager.Player.Player1) ;
        GameManager.instance.removeGem(targetPlayer);
        Debug.Log("Only Blue");
    }
}
