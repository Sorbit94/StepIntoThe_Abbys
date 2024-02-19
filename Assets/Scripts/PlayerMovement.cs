using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimations playerAnimations;
    private bool isGrounded;
    private bool isJumpAvailable = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        if (isGrounded)
        {
            playerAnimations.SetJumping(false);
            playerAnimations.SetFalling(false);
            isJumpAvailable = true;
        }
        else if (rb.velocity.y < 0)
        {
            playerAnimations.SetJumping(false);
            playerAnimations.SetFalling(true);
        }
        else
        {
            playerAnimations.SetJumping(true);
            playerAnimations.SetFalling(false);
        }
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();

        if (Mathf.Abs(direction) > 0.01f)
        {
            if (direction < 0)
                spriteRenderer.flipX = true;
            else if (direction > 0)
                spriteRenderer.flipX = false;

            HorizontalMovement(direction);
            playerAnimations.SetRunning(true);
        }
        else
        {
            playerAnimations.SetRunning(false);
        }
    }

    private void Jump()
    {
        if (isGrounded && isJumpAvailable)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAnimations.SetJumping(true);
            isJumpAvailable = false;
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
