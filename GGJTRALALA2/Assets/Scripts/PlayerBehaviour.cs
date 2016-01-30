using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameManager.Player thisPlayer;
    protected bool canAct = false;

	// Use this for initialization
	protected virtual void Start () {
        if (GameManager.instance.ReturnPlayer() == thisPlayer)
        {
            Debug.Log("Firstplayer: " + thisPlayer);
            canAct = true;
        }
        else
            Debug.Log(GameManager.instance.ReturnPlayer());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool toggleCanAct(bool setTrue = false)
    {
        if(setTrue)
        {
            canAct = true;
            return canAct;
        }
        canAct = !canAct;
        return canAct;
    }
}
