using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    const float _SCROLLING_SPEED = 2f;
    const float _ACCELERATION = 0.08f;
    float _speed = 0;
    const float _START_POSITION = 4389;
    const float _END_POSITION = 5;
    const float _BOTTOM_REACHED_THRESHOLD = 200;
    bool _scrolling = false;
    RectTransform rect;
    float position;
    SnowFlakeSpawner _spawner;
    bool _playing;

    public delegate void LevelControllerEvent();
    public LevelControllerEvent BottomAlmostReached;
    public LevelControllerEvent BottomReached;
    public void Init()
    {
        _scrolling = false;
        rect = transform.GetComponent<RectTransform>();
        _spawner = transform.Find("Background/FlakeHolder/Spawner").GetComponent<SnowFlakeSpawner>();
    }

    public void Prepare()
    {
        position = _START_POSITION;
        _StartGame();
    }

    void _StartGame()
    {
        _scrolling = true;
        _playing = true;
    }

	void Update () {
        if (_scrolling)
        {       
            if(position <= _END_POSITION + _BOTTOM_REACHED_THRESHOLD && _playing)
            {
                if (BottomAlmostReached != null)
                {
                    BottomAlmostReached();
                }
                _playing = false;
            }
            else if (!(position <= _END_POSITION))
            {
                if (_speed < _SCROLLING_SPEED)
                {
                    _speed += _ACCELERATION;
                    position -= _speed;
                }
                else
                {
                    position -= _SCROLLING_SPEED;
                }
                rect.offsetMin = new Vector2(rect.offsetMin.x, -position);
                rect.offsetMax = new Vector2(rect.offsetMax.x, -position);
            }
            else
            {
                if (BottomReached != null)
                {
                    BottomReached();
                }
                _spawner.StartSnowfall();
                _scrolling = false;
            }
        }
    }
}
