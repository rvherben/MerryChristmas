using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    LevelController _levelController;
    Transform _startingSleighView;
    StartingSleigh _currentSleigh;
    GameObject _playerView;
    PlayerController _playerController;
    EnemySpawner _enemySpawner;
    UIController _menuView;
    const float _SLEIGH_DELAY = 2f;


    public override void Init()
    {
        _levelController = GameObject.Find("Canvas").transform.Find("MainView").GetComponent<LevelController>();
        _levelController.Init();
        _startingSleighView = _levelController.transform.parent.transform.Find("StartingSleighView").transform;
        _playerView = _levelController.transform.parent.transform.Find("PlayerView").gameObject;
        _playerController = _playerView.transform.Find("Player").GetComponent<PlayerController>();
        _enemySpawner = _levelController.transform.parent.transform.Find("EnemyView").GetComponent<EnemySpawner>();
        _enemySpawner.Init();
        _menuView = _levelController.transform.parent.transform.Find("MenuView/ChristmasCard/Card/StartButton").GetComponent<UIController>();
    }

    public void StartGame()
    {
        Invoke("_SpawnSleigh", _SLEIGH_DELAY);
        _levelController.BottomAlmostReached += _OnBottomAlmostReached;
        _levelController.BottomReached += _OnBottomReached;
        _enemySpawner.StartEnemySpawnRotation();
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

    public void SantaHit()
    {
        _levelController.HandleOnSantaHit();
        _enemySpawner.StopEnemySpawnRotation();
    }

    public void Reset()
    {
        _playerController.Reset();
        _levelController.Reset();
        _menuView.Reset();
    }

    void _OnBottomAlmostReached()
    {
        _levelController.BottomAlmostReached -= _OnBottomAlmostReached;

        _playerController.HandleBottomAlmostReached();
        _enemySpawner.StopEnemySpawnRotation();
    }

    void _OnBottomReached()
    {
        _levelController.BottomReached -= _OnBottomReached;
        _playerController.HandleBottomReached();
        
    }
}
