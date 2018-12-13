using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int health;
    public int LevelToLoad;

    public Slider healthBar;

	void Update () {  
      if (health <= 0){
            Destroy(gameObject);
            Application.LoadLevel(LevelToLoad);
        }
        healthBar.value = health;
	}

    public void TakeDamage (int damage) {
        health -= damage;
        Debug.Log("Damage!!!!");
    }
}
