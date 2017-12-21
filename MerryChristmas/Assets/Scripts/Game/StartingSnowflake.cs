using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSnowflake : MonoBehaviour {

    const float _FALLING_SPEED = -0.6f;
    const float _DESTROY_DELAY = .5f;
    const float _SINE_FREQUENCY = 0.05f;
    const float _SINE_AMPLITUDE = 0.5f;
    float _frequency = 1;
    bool _started = false;
    Vector3 _startPosition;

    void Start()
    {
        Invoke("_StartFalling", Random.Range(0, 1.5f));
    }

    void _StartFalling()
    {
        _started = true;
    }

    void Update()
    {
        if (_started)
        {
            _frequency += _SINE_FREQUENCY;
            float speed = _FALLING_SPEED;
            transform.localPosition += new Vector3(_SINE_AMPLITUDE * (Mathf.Sin(_frequency)), speed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Invoke("_Destroy", _DESTROY_DELAY);
        }
    }

    void _Destroy()
    {
        Destroy(gameObject);
    }
}
