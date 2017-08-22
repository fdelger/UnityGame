using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image currenthealthbar;
    public Text healthratio;
    public Color myColor;
    public float HP = 100;
    private float MaxHP = 100;
    private float damage = 10;

	// Use this for initialization
    
	void Start () {
        UpdateHealthBar();
	}

 	private void UpdateHealthBar () {
        float ratio = HP / MaxHP;
        currenthealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthratio.text = (ratio*100).ToString() + '%';
        if (ratio > 0.4 && ratio < 0.8)
        {
            currenthealthbar.color = Color.yellow;
        }
        if (ratio < 0.4)
            currenthealthbar.color = Color.red;
        if (ratio >= 0.8)
            currenthealthbar.color = Color.green;
        
		
	}
    public void TakeDamage()
    {
        HP -= damage;
        UpdateHealthBar();
    }
    public void Heal()
    {
        HP += 30;
        UpdateHealthBar();

    }
    public void TakeSpecial()
    {
        HP -= 60;
        UpdateHealthBar();
    }
}
