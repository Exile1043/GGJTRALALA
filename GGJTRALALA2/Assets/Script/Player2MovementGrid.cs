using UnityEngine;
using System.Collections;

public class Player2MovementGrid : MonoBehaviour {

    Vector3 pos;
    public float speed;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position == pos)
        {
            pos += Vector3.left;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position == pos)
        {
            pos += Vector3.right;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position == pos)
        {
            pos += Vector3.up;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position == pos)
        {
            pos += Vector3.down;
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

    }
}