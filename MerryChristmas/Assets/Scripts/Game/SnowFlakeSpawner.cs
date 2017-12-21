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

    void _Init()
    {
        _flakeSpawnArea = transform.parent.transform;
        _initialized = true;
    }

    public void StartSnowfall()
    {
        if (!_initialized)
        {
            _Init();
        }
        _snowing = true;
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
                flake.GetComponent<SnowFlake>().SetSnowFlakeProperties(randomSize, new Vector3(randomPos, transform.localPosition.y, transform.localPosition.z));
                _cooldown = _SNOW_DENSITY;
            }
            else
            {
                _cooldown--;
            }
        }
    }
}
