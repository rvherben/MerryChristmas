using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeSpawner : MonoBehaviour
{
    bool _snowing = false;
    const float _SNOW_DENSITY = 1.2f;
    float _cooldown = 0;
    Transform _flakeSpawnArea;
    bool _initialized = false;
    const float _FASTFALL_DURATION = 3f;
    const int _FASTFALL_DENSITY_MULTIPLIER = 5;
    bool _fastFall=false;

    void _Init()
    {
        _flakeSpawnArea = transform.parent.transform;
        _initialized = true;
    }

    void Start()
    {
        if (!_initialized)
        {
            _Init();
        }
        _snowing = true;
        _fastFall = true;
        Invoke("_StopFastFall", _FASTFALL_DURATION);
    }

    void _StopFastFall()
    {
        _fastFall = false;
    }

    void Update()
    {
        if (_snowing)
        {
            if (_cooldown <= 0)
            {
                GameObject flake = (GameObject)Instantiate(Resources.Load("Flake"));
                flake.transform.SetParent(_flakeSpawnArea);
                float randomPos = Random.Range(-330, 330);
                float randomSize = Random.Range(0.05f, 0.2f);
                if (_fastFall)
                {
                    flake.GetComponent<SnowFlake>().SetSnowFlakeProperties(randomSize, new Vector3(randomPos, transform.localPosition.y, transform.localPosition.z), true, _FASTFALL_DURATION);
                    _cooldown = _SNOW_DENSITY / _FASTFALL_DENSITY_MULTIPLIER;
                }
                else
                {
                    flake.GetComponent<SnowFlake>().SetSnowFlakeProperties(randomSize, new Vector3(randomPos, transform.localPosition.y, transform.localPosition.z));
                    _cooldown = _SNOW_DENSITY;
                }              
                
            }
            else
            {
                _cooldown--;
            }
        }
    }
}
