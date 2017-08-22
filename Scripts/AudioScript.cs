using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    bool playingmusic = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M)) {

            playingmusic = !playingmusic;

            if (playingmusic) {
                gameObject.GetComponent<AudioSource>().Play();
            }

            else
            {
                gameObject.GetComponent<AudioSource>().Stop();
            }

        }

    }
}
