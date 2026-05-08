using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharroController : MonoBehaviour
{
    [Header("Movement configuration")]
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Dash configuration")]
    public float dashForce = 15f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    public float staminaCostDash = 10f;
    private float dashTime;

    [Header("Dash configuration")]
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegen = 3f;

    void Start() // Execution at start
    {
        rb = GetComponent<Rigidbody2D>(); // Search the rigidbody
        currentStamina = maxStamina; // Set the initial stamina
    }

    // Frame upload
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal"); // Horizontal movement (a, d)
        float y = Input.GetAxisRaw("Vertical"); // Vertical movement (w, s)

        movement = new Vector2(x, y).normalized; // Combine both directions, normalized to avoid more speed in diagonals

        if (Input.GetKeyDown(KeyCode.LeftShift) && currentStamina >= staminaCostDash && !isDashing)
        {
            StartDash();
        }
        
        RegenerateStamina();
    }

    void FixedUpdate() // For physics
    {
        if (isDashing) // Controlling the dash
        {
            rb.velocity = movement * dashForce;
            dashTime -= Time.fixedDeltaTime; // Calculates the remain of dash

            if (dashTime <= 0)
            {
                isDashing = false;
            }
        }
        else // Normal situation
        {
            rb.velocity = movement * speed;
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration;
        currentStamina -= staminaCostDash;
    }

    void RegenerateStamina()
    {
        if (currentStamina < maxStamina && !isDashing)
        {
            currentStamina += staminaRegen * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
    }
}
