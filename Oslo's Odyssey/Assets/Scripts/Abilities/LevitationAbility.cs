using UnityEngine;

public class LevitationAbility : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public float levitationDuration = 3f; // Duration of the levitation ability in seconds
    public float levitationForce = 5f; // Force applied to the character during levitation
    public bool isLevitating = false;
    private float levitationTimer = 0f;
    private AbilityBar abilityBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        abilityBar = FindObjectOfType<AbilityBar>();
        
        
        Debug.Log("levitating:" + isLevitating);
        
    }
    
    private void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movementInput = new Vector2(moveHorizontal, moveVertical);
        if (abilityBar != null)
        {
            if (abilityBar.isActiveAndEnabled)
            {
                if (abilityBar.abilityBarSlider.value <= 0f)
                {
                    StopLevitation();
                }
            }
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
        if (abilityBar == null)
        {
            abilityBar = FindObjectOfType<AbilityBar>();
        }
        Debug.Log("toggle");
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
        Debug.Log("called");
        if (abilityBar.abilityBarSlider.value >= 1f && !isLevitating)
        {
            isLevitating = true;
            rb.gravityScale = 0f;
            levitationTimer = levitationDuration;
            Debug.Log("start levitation");

        }
    }

    public void StopLevitation()
    {
        if (isLevitating)
        {
            isLevitating = false;
            rb.gravityScale = 5f;
            Debug.Log("stop levitation");

        }
    }
    
    private void FixedUpdate()
    {
        if (isLevitating)
        {
            movementInput.Normalize();
            rb.velocity = movementInput * levitationForce;
        }
    }
}