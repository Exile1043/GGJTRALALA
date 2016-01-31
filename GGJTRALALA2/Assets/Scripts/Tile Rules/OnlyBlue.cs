using UnityEngine;
using System.Collections;

public class OnlyBlue : TileRule {

	public override void ApplyRule(PlayerBehaviour targetPlayer)
    {
        if (targetPlayer.ReturnPlayer() == GameManager.Player.Player2)
        {
            GameManager.instance.removeGem(targetPlayer);
        }
        Debug.Log("Only Blue");
    }
}
