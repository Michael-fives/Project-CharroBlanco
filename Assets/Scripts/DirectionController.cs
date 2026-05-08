using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    [Header("Body configuration")]
    public SpriteRenderer head;
    public SpriteRenderer poncho;
    public SpriteRenderer legs;

    [Header("Sprite configuration")]
    public Sprite headFront, headBack, headSide;
    public Sprite ponchoFront, ponchoBack, ponchoSide;
    public Sprite legsFront, legsBack, legsSide;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position; // Get the mouse position

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360; // Normalizate the angle

        // Seeing right
        if (angle >= 315 || angle < 45)
        {
            SetSide(false);
        }
        // Seeing up
        else if (angle >= 45 && angle < 135)
        {
            SetBack();
        }
        // Seeing left
        else if (angle >= 135 && angle < 225)
        {
            SetSide(true);
        }
        // Seeing down
        else
        {
            SetFront();
        }
    }

    void SetFront()
    {
        head.sprite = headFront;
        poncho.sprite = ponchoFront;
        legs.sprite = legsFront;

        legs.sortingOrder = 0;
        poncho.sortingOrder = 1;
        head.sortingOrder = 2;

        Flip(false);
    }
    void SetBack()
    {
        head.sprite = headBack;
        poncho.sprite = ponchoBack;
        legs.sprite = legsBack;

        legs.sortingOrder = 2;
        poncho.sortingOrder = 1;
        head.sortingOrder = 0;

        Flip(false);
    }

    void SetSide(bool flip)
    {
        head.sprite = headSide;
        poncho.sprite = ponchoSide;
        legs.sprite = legsSide;

        legs.sortingOrder = 0;
        poncho.sortingOrder = 1;
        head.sortingOrder = 2;

        Flip(flip);
    }

    void Flip(bool flip)
    {
        head.flipX = flip;
        poncho.flipX = flip;
        legs.flipX = flip;
    }
}
