using UnityEngine;
using System.Collections;

public class NoImplement : TileRule {

    public override void ApplyRule(PlayerBehaviour targetPlayer)
    {
        if (targetPlayer.ReturnPlayer() == GameManager.Player.Player1)
        {
            if (GameManager.instance.inventoryP1 > 0)
                GameManager.instance.removeGem(targetPlayer);
        }
        else if (targetPlayer.ReturnPlayer() == GameManager.Player.Player2)
        {
            if (GameManager.instance.inventoryP2 > 0)
                GameManager.instance.removeGem(targetPlayer);
        }
        Debug.Log("Only Implement");
    }
}
