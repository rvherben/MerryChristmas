using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : Singleton<GeneralManager> {

	void Start () {
        GameManager.Instance.Init();
	}
	
}
