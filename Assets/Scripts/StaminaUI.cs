using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public CharroController player;
    public Image staminaFill;
    public CanvasGroup staminaBarRoot;

    [Header("Color configuration")]
    public Color normalColor = Color.white;
    public Color lowStaminaColor = Color.red;

    [Header("Fade configuration")]
    public float fadeSpeed = 30f;
    public float targetAlpha = 0f;

    void Update() // Draws the actual stamina amount
    {
        if (player == null || staminaFill == null || staminaBarRoot == null) return;

        // Stamina variables
        float current = player.currentStamina;
        float max = player.maxStamina;
        staminaFill.fillAmount = current / max;

        // Visibility logic
        if (current < max)
        {
            targetAlpha = 1f;
        }
        else
        {
            targetAlpha = 0f;
        }
        staminaBarRoot.alpha = Mathf.Lerp(staminaBarRoot.alpha, targetAlpha, Time.deltaTime * fadeSpeed);

        // Color logic
        if (current < 10f)
        {
            staminaFill.color = lowStaminaColor;
        }
        else
        {
            staminaFill.color = normalColor;
        }
    }
}
