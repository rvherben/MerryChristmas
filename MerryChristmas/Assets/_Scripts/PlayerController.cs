using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _goingLeft, _goingRight, _goingUp, _goingDown, _isFalling, _grounded;
    public float speed = 1;
    public Sprite santaDead;
    public GameObject Parachute;


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
        if (!_isFalling) {
            Move(_goingLeft, _goingRight, _goingUp, _goingDown);
        } else
        {
            Fall();
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), Mathf.Clamp(transform.position.y, 3.0f, 11.5f));
    }

    void Fall()
    {
        if (!_grounded)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        }

    void Move(bool left, bool right, bool up, bool down)
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

    void ChangeSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
            if (_isFalling)
            {
                ChangeSprite(santaDead);
                //Invoke()
            }
            else {
                //win the game
            }

        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            _isFalling = true;
            Destroy(Parachute);
            
        }
        
    } 

    void Reset()
    {

    }

    
}
