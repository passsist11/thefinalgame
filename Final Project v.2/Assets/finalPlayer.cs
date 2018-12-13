using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalPlayer : MonoBehaviour
{

    public int health;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        moveVelocity = moveInput.normalized * speed;

  
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
