using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text uiText;
    private float timer = 0.0f;

    // Use this for initialization
    private void Start()
    {
        uiText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update () {
        
        int minutes;
        int seconds;
        string niceTime;
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60f);
        seconds = Mathf.FloorToInt(timer % 60f);

        uiText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");



    }
}
