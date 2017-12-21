using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    LevelController _levelController;
    Transform _startingSleighView;
    StartingSleigh _currentSleigh;
    GameObject _playerView;
    PlayerController _playerController;
    const float _SLEIGH_DELAY = 2f;


    override public void Init()
    {
        _levelController = GameObject.Find("Canvas").transform.Find("MainView").GetComponent<LevelController>();
        _levelController.Init();
        _startingSleighView = _levelController.transform.parent.transform.Find("StartingSleighView").transform;
        _playerView = _levelController.transform.parent.transform.Find("PlayerView").gameObject;
        _playerController = _playerView.transform.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame()
    {
        Invoke("_SpawnSleigh", _SLEIGH_DELAY);
        _levelController.BottomAlmostReached += _OnBottomAlmostReached;
        _levelController.BottomReached += _OnBottomReached;
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

    void _OnBottomAlmostReached()
    {
        _levelController.BottomAlmostReached -= _OnBottomAlmostReached;

        _playerController.HandleBottomAlmostReached();
    }

    void _OnBottomReached()
    {
        _levelController.BottomReached -= _OnBottomReached;

        _playerController.HandleBottomReached();
    }
}
