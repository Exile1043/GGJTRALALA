using UnityEngine;
using System.Collections;

public class TileContents : MonoBehaviour {

    private TileRule Rule; //
    private GameObject Gem;

    private SpriteRenderer spriteRenderer;
    public Sprite Direction;
    public Sprite OnlyGreen;
    public Sprite OnlyBlue;
    public Sprite NoImplement;
    public Sprite OnlyImplement;
    public Sprite NoRule;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	public TileRule ReturnRule()
    {
        if (Rule != null)
            return Rule;
        else
            return null;
    }

    public TileRule SetRule(TileRule newRule, string sprite)
    {

        Rule = newRule;

        switch (sprite)
        {
            case "Direction":
                spriteRenderer.sprite = Direction;
                break;
            case "OnlyGreen":
                spriteRenderer.sprite = OnlyGreen;
                break;
            case "OnlyBlue":
                spriteRenderer.sprite = OnlyBlue;
                break;
            case "NoImplement":
                spriteRenderer.sprite = NoImplement;
                break;
            case "OnlyImplement":
                spriteRenderer.sprite = OnlyImplement;
                break;
        }

        return newRule;
    }

    public void ClearRule()
    {
        spriteRenderer.sprite = NoRule;
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
