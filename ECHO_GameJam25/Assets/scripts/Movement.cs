using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    public float moveSpeed = 9f;
    public float acceleration = 80f;
    public float deceleration = 60f;
    public float airControl = 0.5f;

    [Header("Jump Settings")]
    public float jumpForce = 16f;
    public float gravityScale = 4f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.08f;
    public LayerMask groundLayer;

    [Header("Coyote Time")]
    public float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    [Header("Dash Settings")]
    public float dashSpeed = 25f;
    public float dashTime = 0.15f;
    public float dashCooldown = 0.5f;

    private bool isDashing;
    private float dashTimeLeft;
    private float dashCooldownTimer;
    private Vector2 dashDirection;

    [Header("Wall Check")]
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float wallCheckRadius = 0.08f;
    private bool onWall = false;

    [Header("Wall Jump Settings")]
    public float wallSlideSpeed = -2f;
    public float wallJumpForceX = 12f;
    public float wallJumpForceY = 16f;
    public float wallJumpTime = 0.2f;

    private bool isWallSliding;
    private int wallDirection; 
    private float wallJumpCounter;

    private float inputX;
    private bool isGrounded;
    private int lastWallJumpDirection = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    private void Update()
    {
        HandleInput();
        CheckGround();

        if (jumpBufferCounter > 0f)
            jumpBufferCounter -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        HandleMovement();

        
        CheckWall();

        
        if (wallJumpCounter > 0f)
        {
            wallJumpCounter -= Time.fixedDeltaTime;
            return; 
        }


        
        if (jumpBufferCounter > 0f)
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpBufferCounter = 0f;
                coyoteTimeCounter = 0f;
                
            }
            else if (onWall) 
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.linearVelocityY = 0f;
                }
                rb.linearVelocity = new Vector2(-wallDirection, wallJumpForceY/2);
                wallJumpCounter = 0;
                isWallSliding = false;
                jumpBufferCounter = 0f;
                
            }
        }



        if (isDashing)
        {
            rb.linearVelocity = dashDirection * dashSpeed;
            dashTimeLeft -= Time.fixedDeltaTime;

            if (dashTimeLeft <= 0f)
                isDashing = false;
        }
        else if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.fixedDeltaTime;
        }
    }

    private void HandleInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");

       
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;

        
        if (Input.GetButtonDown("Dash") && dashCooldownTimer <= 0f && !isDashing)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            dashDirection = new Vector2(x, y).normalized;
            if (dashDirection == Vector2.zero)
                dashDirection = Vector2.right;

            isDashing = true;
            dashTimeLeft = dashTime;
            dashCooldownTimer = dashCooldown;

            dashDirection = new Vector2(x, y).normalized;
            dashDirection.y *= 0.5f;

        }
    }

    private void HandleMovement()
    {
        if (wallJumpCounter > 0)
        {
            wallJumpCounter -= Time.fixedDeltaTime;
            return; 
        }

        float targetSpeed = inputX * moveSpeed;
        float speedDiff = targetSpeed - rb.linearVelocity.x;
        float accel = Mathf.Abs(targetSpeed) > 0.01f ? (isGrounded ? acceleration : acceleration * airControl) : (isGrounded ? deceleration : deceleration * airControl);
        float movement = accel * speedDiff * Time.fixedDeltaTime;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x + movement, rb.linearVelocity.y);

        
        if (isWallSliding)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, wallSlideSpeed));
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    private void CheckWall()
    {
        isWallSliding = false;
        wallDirection = 0;

        if (Physics2D.OverlapCircle(wallCheckLeft.position, wallCheckRadius, groundLayer))
            wallDirection = -1;
        else if (Physics2D.OverlapCircle(wallCheckRight.position, wallCheckRadius, groundLayer))
            wallDirection = 1;

        if (wallDirection != 0 && !isGrounded && rb.linearVelocity.y < 0)
            isWallSliding = true;
            onWall = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        if (wallCheckLeft != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(wallCheckLeft.position, wallCheckRadius);
        }

        if (wallCheckRight != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(wallCheckRight.position, wallCheckRadius);
        }
    }
}
