using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _goingLeft, _goingRight, _brake, _accelerate;
	
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
            _brake = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _brake = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _accelerate = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _accelerate = false;
        }

        Fall(_goingLeft, _goingRight, _brake, _accelerate);

    }

    void Fall(bool left, bool right, bool up, bool down)
    {
        if (left)
        {
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y - 0.01f);
        } else if (right)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y - 0.01f);
        }else if (left && right || !left && !right)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        }

        if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.005f);
        }
        if(down){
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.005f);
        }
    }

    
}
