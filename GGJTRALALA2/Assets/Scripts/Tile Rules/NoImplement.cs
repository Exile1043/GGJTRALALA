﻿using UnityEngine;
using System.Collections;

public class NoImplement : TileRule {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void ApplyRule(GameManager.Player targetPlayer)
    {
        Debug.Log("NoImplement");
    }
}
