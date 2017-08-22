using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscrip : MonoBehaviour {
    public float orthographicSize = 5;
    public float aspect = 1.33333f;
    Camera camera;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                camera.nearClipPlane, camera.farClipPlane);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
