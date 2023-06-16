using UnityEngine;

public class LevitationAbility : MonoBehaviour
{
    public float levitationDuration = 3f; // Duration of the levitation ability in seconds
    public float levitationForce = 10f; // Force applied to the character during levitation
    public bool isLevitating = false;
    private bool isDropping = false;
    private float levitationTimer = 0f;
    private Rigidbody2D characterRigidbody;
    private Vector2 movementInput;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isLevitating)
        {
            levitationTimer -= Time.deltaTime;
            if (levitationTimer <= 0f)
            {
                StopLevitation();
            }
        }

        if (isDropping)
        {
            StopLevitation();
        }
    }

    public void StartLevitation()
    {
        if (!isLevitating && !isDropping)
        {
            isLevitating = true;
            characterRigidbody.gravityScale = 0f; // Set gravity scale to zero for the character
            levitationTimer = levitationDuration;
        }
    }

    public void StopLevitation()
    {
        if (isLevitating || isDropping)
        {
            isLevitating = false;
            isDropping = false;
            characterRigidbody.gravityScale = 1f; // Restore the original gravity scale for the character
            characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, 0f); // Stop the character's vertical velocity
        }
    }

    private void FixedUpdate()
    {
        if (isLevitating)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movementInput = new Vector2(moveHorizontal, moveVertical);
            movementInput.Normalize();
        }
        else if (isDropping)
        {
            movementInput = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        if (isLevitating)
        {
            characterRigidbody.AddForce(movementInput * levitationForce, ForceMode2D.Force);
        }
        else if (isDropping)
        {
            characterRigidbody.AddForce(Vector2.down * levitationForce, ForceMode2D.Force);
        }
    }

    public void Drop()
    {
        if (isLevitating)
        {
            isDropping = true;
        }
    }
}
