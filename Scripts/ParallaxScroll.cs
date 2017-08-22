using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour {
    public float parallaxSpeed;
    private Transform cameraTransform;
    private float cameraMove;

	// Use this for initialization
	void Start () {
        cameraTransform = Camera.main.transform;
        cameraMove = cameraTransform.position.x;
		
	}
	
	// Update is called once per frame
	void Update () {
        float deltaCamera = cameraTransform.position.x - cameraMove;
        transform.position += Vector3.right * (deltaCamera * parallaxSpeed);
        cameraMove = cameraTransform.position.x;
	}
}
