using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowFlake : MonoBehaviour {

    const float _FALLING_SPEED = -0.6f;
    const float _DESTROY_DELAY = .5f;
    const float _SINE_FREQUENCY = 0.05f;
    const float _SINE_AMPLITUDE = 0.5f;
    float _frequency = 1;
    bool _initialized = false;
    Vector3 _startPosition;

    void _Init()
    {
        _initialized = true;
    }

    public void SetSnowFlakeProperties(float size, Vector3 position, float alpha)
    {
        if (!_initialized)
        {
            _Init();
        }
        transform.localScale = new Vector3(size, size, size);
        transform.localPosition = position;
        _startPosition = transform.localPosition;
        Color32 c = transform.GetComponent<Image>().color;

        c.a = (byte)alpha;
        transform.GetComponent<Image>().color = c;
    }

    void Update () {
        if (_initialized)
        {
            _frequency += _SINE_FREQUENCY;
            float speed = _FALLING_SPEED;
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
