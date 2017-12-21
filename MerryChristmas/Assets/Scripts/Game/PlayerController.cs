using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool _goingLeft, _goingRight, _goingUp, _goingDown, _isFalling, _grounded;
    public float speed = 6;
    public Sprite santaDead;
    public GameObject Parachute;
    bool _playing = true;
    bool _bottomReached = false;

    public void HandleBottomAlmostReached()
    {
        _playing = false;
    }

    public void HandleBottomReached()
    {
        _bottomReached = true;
    }

    // Update is called once per frame
    void Update () {
        if (_playing && !_bottomReached)
        {
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
            if (!_isFalling)
            {
                Move(_goingLeft, _goingRight, _goingUp, _goingDown);
            }
            else
            {
                Fall();
            }

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), Mathf.Clamp(transform.position.y, 6, 11.5f));
        }
        else if (_bottomReached && !_grounded)
        {
            transform.localPosition -= new Vector3(0, 2, 0);
        }
        
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
                Destroy(Parachute);
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
        _playing = true;
        _bottomReached = false;
    }

    
}
