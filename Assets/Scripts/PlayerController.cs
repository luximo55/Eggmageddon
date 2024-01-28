using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    Vector2 movementInput;
    Rigidbody2D rb;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private PlayerAnimator playerAnimator;
    private bool facingRight = true;
    private float xDirection;

    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();

    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
    
        Debug.Log(xDirection);
        
        if(xDirection >0 && facingRight == false)
        {
            Flip();
        }
        else if(xDirection < 0 && facingRight == true)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            playerAnimator.Moving();
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

            }
        }
        else if (movementInput == Vector2.zero)
        {
            playerAnimator.NotMoving();
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                direction
                , movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }



}
