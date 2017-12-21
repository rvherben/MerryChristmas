using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _goingLeft, _goingRight, _goingUp, _goingDown;
    public float speed = 1;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _goingLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _goingLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _goingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _goingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _goingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _goingUp = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _goingDown = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _goingDown = false;
        }

        Fall(_goingLeft, _goingRight, _goingUp, _goingDown);

    }

    void Fall(bool left, bool right, bool up, bool down)
    {
        if (left)
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if (right)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (up)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (down)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    
}
