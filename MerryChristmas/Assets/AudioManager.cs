using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.loop = true;
        audio.volume = 0.05f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
