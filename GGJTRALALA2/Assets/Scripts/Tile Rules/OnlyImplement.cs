﻿using UnityEngine;
using System.Collections;

public class OnlyImplement : TileRule {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void ApplyRule()
    {
        Debug.Log("Only Implement");
    }
}
