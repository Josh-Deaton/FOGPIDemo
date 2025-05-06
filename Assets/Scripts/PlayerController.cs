using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float horizontalInput;
    public float moveSpeed;
    public float jumpForce;
    public float wallJumpForce;

    private Rigidbody2D rb2d;

    // Check if the player is grounded or near a wall
    private bool isGrounded;
    private bool isTouchingWall;

    // Layer for the ground and wall to ensure we only check relevant collisions
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for horizontal movement (left and right)
        float moveInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb2d.linearVelocity.y) < 0.001f)
        {
            rb2d.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
        }


    }

    public void FixedUpdate()
    {
        // Check if player is grounded using an OverlapCircle
        isGrounded = Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.5f, 0), 0.1f, groundLayer);

        // Debugging
        if (isGrounded)
        {
            Debug.Log("Player is grounded");
        }

        // Debugging the raycast for ground detection
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        if (hit.collider != null)
        {
            Debug.Log("Ground hit by raycast");
        }

        // Check if the player is touching a wall
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, groundLayer) ||
                          Physics2D.Raycast(transform.position, Vector2.left, 0.1f, groundLayer);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Handle wall jumping
        if (isTouchingWall && !isGrounded && Input.GetButtonDown("Jump"))
        {
            WallJump();
        }
    }

    // Method to make the player jump
    void Jump()
    {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
    }

    // Method to perform a wall jump
    void WallJump()
    {
        // Apply a jump force with a horizontal push in the opposite direction of the wall
        rb2d.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForce, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player collided with ground");
        }
    }

}