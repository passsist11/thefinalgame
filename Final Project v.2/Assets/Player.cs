using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 3; 
    public float speed = 10f;
    public float jumpPower = 150f;

    public bool grounded;
    public bool canDoubleJump;

    public int curHealth;
    public int maxHealth = 100;

    private Rigidbody2D rb2d;
    private Animator anim;
	
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
	}
	

	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); 

        //flip when facing different direction 
        //if (Input.GetAxis("Horizontal") < -0.1f){
        //    transform.localPosition = new Vector3(-1, 1, 1);
        //}
        //if (Input.GetAxis("Horizontal") > 0.1f)
        //{
        //    transform.localPosition = new Vector3(1, 1, 1);
        //}

        if(Input.GetButtonDown("Jump")){
            if(grounded){
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else{
                if(canDoubleJump){
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower);
                }
            }
        }

        if (curHealth > maxHealth){
            curHealth = maxHealth;
        }
        if(curHealth <= 0){
            Die();  
        }
    }

    void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * h);

        if(rb2d.velocity.x > maxSpeed){
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Die () {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage (int dmg) {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("BH Red");
    }

    public IEnumerator Knockback (float knockDur, float knockbackPwr, Vector3 knockbackDir) {
        float timer = 0;
        while(knockDur > timer){
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }
}
