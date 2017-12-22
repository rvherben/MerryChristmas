using UnityEngine;

public class SantaMovement : MonoBehaviour {

    float _amplitude;
    float _frequency;
    float _speed;
    bool _moveLeft;
    bool _initialized;
    bool _started;

    const float _SINE_FREQUENCY = 0.1f;

    void _Init()
    {
        _amplitude = 1f;
        _frequency = 0f;
        _speed = 5;
    }

    public void SetProperties(bool left, float posY)
    {
        if (!_initialized)
        {
            _Init();
        }
        float x = 0;
        _moveLeft = left;
        if (_moveLeft)
        {
            x = 389;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            x = -389;
            transform.localScale = Vector3.one;
        }
        transform.localPosition = new Vector3 (x, posY, 0);
        _started = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (_started)
        {
            _frequency += _SINE_FREQUENCY;
            if (_moveLeft)
            {
                transform.localPosition -= new Vector3(_speed, _amplitude * (Mathf.Sin(_frequency)), 0);
                transform.localPosition += new Vector3(0, 1, 0);
                if (transform.localPosition.x < -389)
               {
                   Destroy(gameObject);
               }
            }
            else
            {
                transform.localPosition -= new Vector3(-_speed, _amplitude * (Mathf.Sin(_frequency)), 0);
                transform.localPosition += new Vector3(0, 1, 0);
                if (transform.localPosition.x > 389)
               {
                   Destroy(gameObject);
               }
            }
        }
    }



}
