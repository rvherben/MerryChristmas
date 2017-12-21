using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    LevelController _levelController;
    Transform _startingSleighView;
    StartingSleigh _currentSleigh;
    GameObject _playerView;
    const float _SLEIGH_DELAY = 2f;


    override public void Init()
    {
        _levelController = GameObject.Find("Canvas").transform.Find("MainView").GetComponent<LevelController>();
        _levelController.Init();
        _startingSleighView = _levelController.transform.parent.transform.Find("StartingSleighView").transform;
        _playerView = _levelController.transform.parent.transform.Find("PlayerView").gameObject;
    }

    public void StartGame()
    {
        Invoke("_SpawnSleigh", _SLEIGH_DELAY);
    }

    void _SpawnSleigh()
    {
        GameObject startingSleigh = (GameObject)Instantiate(Resources.Load("Sleigh"));
        startingSleigh.transform.SetParent(_startingSleighView, false);
        _currentSleigh = startingSleigh.GetComponent<StartingSleigh>();
        _currentSleigh.InMiddle += _SpawnPlayer;
    }

    void _SpawnPlayer()
    {
        _currentSleigh.InMiddle -= _SpawnPlayer;
        _playerView.SetActive(true);
        _levelController.Prepare();
    }
}
