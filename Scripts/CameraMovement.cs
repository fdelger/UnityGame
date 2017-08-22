using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject Player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Player.transform.position + offset;
		
	}
}
