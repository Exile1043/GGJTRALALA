using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameManager.Player thisPlayer;
    protected bool canAct = false;

    public List<AudioClip> WalkSoundList;

    void Awake()
    {
        
    }

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

    public void paused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canAct = false;
            Time.timeScale = 0f;
        }
    }


    public void playWalkSound()
    {
        int ranNum = Mathf.FloorToInt(Random.Range(1, 4));
        AudioSource.PlayClipAtPoint(WalkSoundList[ranNum], transform.position);
    }
}
