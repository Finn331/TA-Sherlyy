using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sprintSpeed; // Speed when sprinting
    public float speed; // Current speed
    public float jumpingPower;
    private float defaultSpeed; // Default speed
    private float horizontal;
    private bool isFacingRight = true;

    private bool isSprinting; // Added variable to track sprinting state

    private int jumpsRemaining; // Number of jumps remaining

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator anim;

    private PlayerStatus playerStatus;

    private void Start()
    {
        defaultSpeed = speed;
        jumpsRemaining = 2; // Initialize the number of jumps remaining to 2

        // Component Reference for private variables
        playerStatus = GetComponent<PlayerStatus>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Check if "Shift" key is pressed
        {
            isSprinting = true;
            speed = sprintSpeed; // Set the speed to sprint speed
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // Check if "Shift" key is released
        {
            isSprinting = false;
            speed = defaultSpeed; // Set the speed back to default
        }
    }

    private void FixedUpdate()
    {
        // Move the player horizontally
        Move();
        
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", IsGrounded());
        Flip();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpsRemaining = 1; // Reset jumps remaining when grounded
            anim.SetTrigger("jump");
        }
        else if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpsRemaining--; // Decrease jumps remaining when performing a double jump
            anim.SetTrigger("jump");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    void Die() // Not Implemented Yet
    {
        if (playerStatus.currHealth == 0)
        {
            // Animasi Death & Checkpoint Logic
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
