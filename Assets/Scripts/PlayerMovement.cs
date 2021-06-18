using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveInput;

    public float speed;
    public float jumpForce;
    public float checkRadius;

    //public float health = 10f;

    public Transform feetPos;
    
    public LayerMask whatIsGround;

    private bool facingRight = true;
    private bool isGround;
    private bool isJumping;

    private bool firstTime = true;
    private bool isFalling = false;
    private Vector3 previousPosition;
    private float highestPosition;


    //for healthsystem
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
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

        if (!isGround)
        {
            if(transform.position.y < previousPosition.y && firstTime)
            {
                firstTime = false;
                isFalling = true;
                highestPosition = transform.position.y;
            }
            previousPosition = transform.position;
        }

        if(isGround && isFalling)
        {
            if(highestPosition - transform.position.y >= 5)
            {
                TakeDamage(40);
                Debug.Log(currentHealth);
            }
            isFalling = false;
            firstTime = true;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
