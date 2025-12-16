using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpHeight = 10f;

    private float horizontalInput;
    [SerializeField] private int numberOfJumps = 1;

    bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.1f), 0f, Vector2.down, 0.93f, LayerMask.GetMask("Ground"));
    }

    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling,
        DoubleJump
    }

    MovementState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

        // Flip sprite based on movement direction, even in air
        if (horizontalInput < 0)
            sprite.flipX = true;
        else if (horizontalInput > 0)
            sprite.flipX = false;

        UpdateMovementState();

        // Removed all SetBool calls, only use SetInteger for state
        anim.SetInteger("currentState", (int)currentState);

        if (Input.GetKeyDown(KeyCode.Space) && numberOfJumps > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);

            // If jumping in air, set DoubleJump state
            if (!IsGrounded() && numberOfJumps == 1)
                currentState = MovementState.DoubleJump;

            numberOfJumps--;
        }
    }

    private void UpdateMovementState()
    {
        if (rb.linearVelocity.y > 0.1f)
        {
            currentState = MovementState.Jumping;
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            currentState = MovementState.Falling;
        }
        else if (Mathf.Abs(rb.linearVelocity.x) > 0.01f)
        {
            currentState = MovementState.Running;
        }
        else
        {
            currentState = MovementState.Idle;
        }
        if (numberOfJumps == 0)
        {
            currentState = MovementState.DoubleJump;
        }
        // Add DoubleJump logic if needed

        if (IsGrounded())
        {
            numberOfJumps = 2;
        }
    }
}