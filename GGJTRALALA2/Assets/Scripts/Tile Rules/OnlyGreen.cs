using UnityEngine;
using System.Collections;

public class OnlyGreen : TileRule {

    public override void ApplyRule(PlayerBehaviour targetPlayer)
    {
        if (targetPlayer.ReturnPlayer() == GameManager.Player.Player1)
        {
            GameManager.instance.removeGem(targetPlayer);
        }
        Debug.Log("Only Blue");
    }
}
