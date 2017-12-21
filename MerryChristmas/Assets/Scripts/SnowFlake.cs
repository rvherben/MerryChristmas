using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour {

    const float _FALLING_SPEED = -0.6f;
    const float _DESTROY_DELAY = .5f;
    const float _SINE_FREQUENCY = 0.05f;
    const float _SINE_AMPLITUDE = 0.5f;
    const int _FASTFALL_SPEED_MULTIPLIER = 5;
    float _frequency = 1;
    bool _initialized = false;
    Vector3 _startPosition;
    bool _fastFall = false;

    void _Init()
    {
        _initialized = true;
    }

    public void SetSnowFlakeProperties(float size, Vector3 position, bool fastFall=false, float fastfallDuration = 0)
    {
        if (!_initialized)
        {
            _Init();
        }
        transform.localScale = new Vector3(size, size, size);
        transform.localPosition = position;
        _startPosition = transform.localPosition;
        if (fastFall)
        {
            _fastFall = true;
            Invoke("_StopFastFall", fastfallDuration);
        }
    }

    void _StopFastFall()
    {
        _fastFall = false;
    }


    void Update () {
        if (_initialized)
        {
            _frequency += _SINE_FREQUENCY;
            float speed = _FALLING_SPEED;
            if (_fastFall)
            {
                speed *= _FASTFALL_SPEED_MULTIPLIER;
            }
            transform.localPosition += new Vector3(_SINE_AMPLITUDE*(Mathf.Sin(_frequency)), speed, 0);
        }      
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Invoke("_Destroy", _DESTROY_DELAY);
        }
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
