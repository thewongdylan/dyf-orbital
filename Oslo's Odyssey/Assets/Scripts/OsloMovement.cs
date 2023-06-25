using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX;
    private float dirY;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    private enum MovementState { idle, running, jumping, falling };

    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        levitationAbility = GetComponent<LevitationAbility>(); // Get the LevitationAbility component
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        if (levitationAbility != null && levitationAbility.isLevitating)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
