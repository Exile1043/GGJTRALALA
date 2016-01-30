using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameManager.Player thisPlayer;
    protected bool canAct;

	// Use this for initialization
	void Start () {
        if (GameManager.instance.ReturnPlayer() == thisPlayer)
            canAct = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool toggleCanAct()
    {
        canAct = !canAct;
        return canAct;
    }
}
