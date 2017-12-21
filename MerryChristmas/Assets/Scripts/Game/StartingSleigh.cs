using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSleigh : MonoBehaviour {

    bool _started = false;
    bool _spawned = false;
    const float _SLEIGH_SPEED = 3f;
    const float _SINE_FREQUENCY = 0.05f;
    const float _SINE_AMPLITUDE = 0.5f;
    float _frequency = 1;

    public delegate void StartingSleighEvent();
    public StartingSleighEvent InMiddle;

    private void Update()
    {
        _frequency += _SINE_FREQUENCY;
        transform.localPosition -= new Vector3(_SLEIGH_SPEED, _SINE_AMPLITUDE * (Mathf.Sin(_frequency)), 0);

        if (transform.localPosition.x<0&&!_spawned)
        {
            if (InMiddle!=null)
            {
                InMiddle();
            }
            _spawned = true;
            transform.Find("Santa").gameObject.SetActive(false);
        }
        if (transform.localPosition.x < -375)
        {
            Destroy(gameObject);
        }
    }
}
