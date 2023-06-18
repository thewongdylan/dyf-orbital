using UnityEngine;

public class LevitationAbility : MonoBehaviour
{
    public float levitationDuration = 3f; // Duration of the levitation ability in seconds
    public float levitationForce = 30f; // Force applied to the character during levitation
    public bool isLevitating = false;
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

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical);
    }

    public void ToggleLevitation()
    {
        if (isLevitating)
        {
            StopLevitation();
        }
        else
        {
            StartLevitation();
        }
    }

    public void StartLevitation()
    {
        if (!isLevitating)
        {
            isLevitating = true;
            characterRigidbody.gravityScale = 0f; // Set gravity scale to zero for the character
            levitationTimer = levitationDuration;
        }
    }

    public void StopLevitation()
    {
        if (isLevitating)
        {
            isLevitating = false;
            characterRigidbody.gravityScale = 5f; // Restore the original gravity scale for the character
        }
    }

    private void FixedUpdate()
    {
        if (isLevitating)
        {
            movementInput.Normalize();
            characterRigidbody.velocity = movementInput * levitationForce;
        }
    }
}
