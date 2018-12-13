using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public int damage;
    public float speed;

    private shake shake; 
    void Start () {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }
  

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        shake.CamShake();
        if (other.CompareTag("Boss"))
        {

            other.GetComponent<Enemy>().health -= damage;
          
            Destroy(gameObject);
        }
    }
}
