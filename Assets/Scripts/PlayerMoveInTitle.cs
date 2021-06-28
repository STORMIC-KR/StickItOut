using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInTitle : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveInput;

    public float speed;
    public float jumpForce;
    public float checkRadius;

    public Transform feetPos;

    public LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGround;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            //Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            //Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
