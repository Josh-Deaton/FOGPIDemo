using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float wallJumpForce = 5f;

    private Rigidbody2D rb2d;
    private bool isGrounded;
    private bool isTouchingWall;
    public LayerMask groundLayer;

    // Reference to check ground position
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        // Ensure proper Rigidbody2D settings
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        // Get player input for horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        
        // Use Rigidbody2D for movement instead of transform
        rb2d.linearVelocity = new Vector2(moveInput * moveSpeed, rb2d.linearVelocity.y);

        // Handle jumping input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Handle wall jumping input
        if (Input.GetButtonDown("Jump") && isTouchingWall && !isGrounded)
        {
            WallJump();
        }
    }

    void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Check if touching wall
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, groundLayer) ||
                        Physics2D.Raycast(transform.position, Vector2.left, 0.1f, groundLayer);
    }

    void Jump()
    {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
    }

    void WallJump()
    {
        rb2d.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForce, jumpForce);
    }
}
