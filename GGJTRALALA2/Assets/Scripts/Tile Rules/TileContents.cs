using UnityEngine;
using System.Collections;

public class TileContents : MonoBehaviour {

    private TileRule Rule; //
    private GameObject Gem;

    public Sprite Direction;
    public Sprite OnlyGreen;
    public Sprite OnlyBlue;
    public Sprite NoImplement;
    public Sprite OnlyImplement;

	public TileRule ReturnRule()
    {
        if (Rule != null)
            return Rule;
        else
            return null;
    }

    public TileRule SetRule(TileRule newRule)
    {

        Rule = newRule;
        return newRule;
    }

    public void ClearRule()
    {
        //Needs to destroy the actual gameobject and remove it from the game.
        Rule = null;
    }

    public GameObject ReturnGem()
    {
        if (Gem)
            return Gem;
        else
            return null;
    }

    public GameObject SetGem(GameObject newGem)
    {
        Gem = newGem;
        return newGem;
    }

    public void ClearGem()
    {
        //Needs to destroy the actual gameobject and remove it from the game.
        Gem = null;
    }
}
