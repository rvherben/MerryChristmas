using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    const float _SCROLLING_SPEED = 3f;
    const float _START_POSITION = 922;
    const float _END_POSITION = 5;
    bool _initialized = false;
    bool _scrolling = false;
    RectTransform rect;
    float position;


    void _Init() {

        _initialized = true;
        rect = transform.GetComponent<RectTransform>();
    }

    public void Prepare()
    {
        if (!_initialized)
        {
            _Init();
        }
        position = _START_POSITION;
        _StartGame();
    }

    void _StartGame()
    {

    }

	void Update () {
        if (_scrolling)
        {
            position -= _SCROLLING_SPEED;
            rect.offsetMin = new Vector2(rect.offsetMin.x, -position);
            rect.offsetMax = new Vector2(rect.offsetMax.x, position);
        }
    }
}
