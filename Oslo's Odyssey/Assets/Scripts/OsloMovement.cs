using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    private enum MovementState { idle, running, jumping, falling };

    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

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

        anim.SetInteger("state", (int) state);
    }

    private bool IsGrounded() 
    // Uses BoxCast to detect for downward overlap with the jumpableGround (hitbox of the ground)
    {
        // 0.1f checks for overlap between hitbox of Player and the jumpableGround
        // This allows jumping when overlapping downwards with the jumpableGround but NOT sideways overlap with other objects
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}