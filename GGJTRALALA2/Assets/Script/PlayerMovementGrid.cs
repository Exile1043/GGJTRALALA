using UnityEngine;
using System.Collections;

public class PlayerMovementGrid : MonoBehaviour {

    Vector3 pos;
    public float speed;

    // Use this for initialization
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(Input.GetKeyDown(KeyCode.A) && transform.position == pos)
        {
            pos += Vector3.left;
        }
        if(Input.GetKeyDown(KeyCode.D) && transform.position == pos)
        {
            pos += Vector3.right;
        }
        if(Input.GetKeyDown(KeyCode.W) && transform.position == pos)
        {
            pos += Vector3.up;
        }
        if(Input.GetKeyDown(KeyCode.S) && transform.position == pos)
        {
            pos += Vector3.down;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
