using UnityEngine;

public class LevitationAbility : MonoBehaviour
{
    public float levitationDuration = 3f; // Duration of the levitation ability in seconds
    public float levitationForce = 5f; // Force applied to the character during levitation
    public bool isLevitating = false;
    private float levitationTimer = 0f;
    private Rigidbody2D characterRigidbody;
    private Vector2 movementInput;

    private AbilityBar abilityBar;


    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        abilityBar = FindObjectOfType<AbilityBar>();
    }

    private void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical);

        if (abilityBar.abilityBarSlider.value <= 0f)
        {
            StopLevitation();
        }

        

        if (isLevitating)
        {
            levitationTimer -= Time.deltaTime;
            if (levitationTimer <= 0f)
            {
                StopLevitation();
            }
        }
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
        if (abilityBar.abilityBarSlider.value >= 1f && !isLevitating)
        {
            isLevitating = true;
            characterRigidbody.gravityScale = 0f;
            levitationTimer = levitationDuration;

        }
    }

    public void StopLevitation()
    {
        if (isLevitating)
        {
            isLevitating = false;
            characterRigidbody.gravityScale = 5f;

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