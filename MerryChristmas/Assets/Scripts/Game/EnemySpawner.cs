using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    const float _FIRST_SPAWN_DELAY = 7f;
    const float _MIN_SPAWN_DELAY = 2f;
    const float _MAX_SPAWN_DELAY = 4.5f;
    Transform _enemySpawnHolder;
    public GameObject player;

	public void Init()
    {
        _enemySpawnHolder = transform.Find("EnemyHolder").transform;
    }

    public void StartEnemySpawnRotation()
    {
        Invoke("_Spawn", _FIRST_SPAWN_DELAY);
    }

    public void StopEnemySpawnRotation()
    {
        CancelInvoke("_Spawn");
    }

    void _Spawn()
    {
        int random = Random.Range(0, 2);
        int random2 = Random.Range(0, 2);
        bool left = false;
        bool bird = false;
        if(random == 1)
        {
            left = true; 
        }
        if(random2 == 1)
        {
            bird = true;
        }
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
        enemy.transform.SetParent(_enemySpawnHolder, false);
        enemy.GetComponent<SantaMovement>().SetProperties(left, player.transform.localPosition.y - Random.Range(50, 100), bird);

        Invoke("_Spawn", Random.Range(_MIN_SPAWN_DELAY, _MAX_SPAWN_DELAY));
    }
}
