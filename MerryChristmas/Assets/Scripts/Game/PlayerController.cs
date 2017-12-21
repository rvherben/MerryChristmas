using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private bool _goingLeft, _goingRight, _goingUp, _goingDown, _isFalling, _grounded;
    public float speed = 6;
    public Sprite santaDead;
    public Sprite santaAlive;
    public GameObject _parachute;
    bool _playing = true;
    bool _bottomReached = false;
    Vector3 _startPos;

    public void Init()
    {
        _startPos = transform.localPosition;
    }

    public void HandleBottomAlmostReached()
    {
        _playing = false;
    }

    public void HandleBottomReached()
    {
        _bottomReached = true;
    }

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isFalling = true;
                _playing = false;
                _parachute.SetActive(false);
                GameManager.Instance.SantaHit();
                transform.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (!_isFalling)
            {
                Move(_goingLeft, _goingRight, _goingUp, _goingDown);
            }

            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), Mathf.Clamp(transform.position.y, 6, 11.5f));
        }
        else if (_bottomReached && !_grounded && !_isFalling)
        {
            transform.localPosition -= new Vector3(0, 2, 0);
        }
        else if (_bottomReached && !_grounded && _isFalling)
        {
            transform.localPosition -= new Vector3(0, 6, 0);
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
        transform.Find("Santa").GetComponent<Image>().sprite = newSprite;
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
                _parachute.SetActive(false);
            }

        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            _isFalling = true;
            _parachute.SetActive(false);
        }
        
    } 

    public void Reset()
    {
        _playing = true;
        _bottomReached = false;
        _isFalling = false;
        _grounded = false;
        _parachute.SetActive(true);
        ChangeSprite(santaAlive);
        transform.GetComponent<BoxCollider2D>().enabled = true;
        transform.localPosition = _startPos;
        transform.parent.gameObject.SetActive(false);
    }

    
}
