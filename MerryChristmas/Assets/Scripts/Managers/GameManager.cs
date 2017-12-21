using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    LevelController _levelController;
    SnowFlakeSpawner _spawner;

    override public void Init()
    {
        _levelController = GameObject.Find("Canvas").transform.Find("MainView").GetComponent<LevelController>();
        _levelController.Init();
        _spawner = _levelController.transform.Find("Background/FlakeHolder/Spawner").GetComponent<SnowFlakeSpawner>();
        _spawner.StartSnowfall();
    }

    public void StartGame()
    {     
        _levelController.Prepare();
    }
}
