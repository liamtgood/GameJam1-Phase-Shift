using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement variables
    public float moveSpeed = 5f;
    // Ground check variables
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Color changer reference
    public PlayerColorChanger colorChanger;
    public static Action playerJumped;

    // Fast fall variables
    public float fastFallGravityScale;

    // Components
    private Rigidbody2D rb;
    // Input actions
    private InputAction jumpAction, moveAction;

    [Header("Animation-related")]
    [SerializeField] float mvmtRangeToAnim;// the range (negative value is lower end) for which player input values should result in a walking animation
    [SerializeField] Animator playerAnimator;
    [SerializeField] SpriteRenderer playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Player horizontal movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        // set direction player character is facing
        playerSprite.flipX = moveInput.x < 0;

        // Player jump
        if (jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            playerJumped?.Invoke();

            // set animation to jump

            colorChanger.ToggleColor();
            rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        } else if (moveInput.x > mvmtRangeToAnim || moveInput.x < -mvmtRangeToAnim)
        {
            // set animation to walking
            playerAnimator.SetBool("IsWalking", true);
        } else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

        // Adjust gravity scale for fast fall
        if (!IsGrounded() && moveInput.y < -0.5f)
        {
            rb.gravityScale = fastFallGravityScale;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private bool IsGrounded()
    {
        // Use groundCheck's localScale as the box size
        Vector2 boxSize = new Vector2(groundCheck.localScale.x, groundCheck.localScale.y);
        Collider2D hit = Physics2D.OverlapBox(groundCheck.position, boxSize, 0f, groundLayer);
        return hit != null;
    }
}
