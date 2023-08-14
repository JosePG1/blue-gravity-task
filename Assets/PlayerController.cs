using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed ;
    public float CollisionOffset ;
    public ContactFilter2D MovementFilter;
    public Animator PlayerAnimator;
    
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D characterRigidbody2D;
    readonly List<RaycastHit2D> castCollisions = new();

    void Start()
    {
        characterRigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerAnimator.SetBool( "isHorizontalMoving", movementInput.x != 0 );
        PlayerAnimator.SetBool( "isMovingUp", movementInput.y > 0 );
        PlayerAnimator.SetBool( "isMovingDown", movementInput.y < 0 );

        if ( movementInput.x > 0  )
        {
            spriteRenderer.flipX = true;
        }else if ( movementInput.x < 0 )
        {
            spriteRenderer.flipX = false;
        }
        
        if ( movementInput != Vector2.zero )
        {
            var moveDirection = movementInput.normalized;

            var absX = Mathf.Abs(moveDirection.x);
            var absY = Mathf.Abs(moveDirection.y);

            if (absX > absY)
            {
                moveDirection.y = 0;
            }
            else
            {
                moveDirection.x = 0;
            }
            
            var count = characterRigidbody2D.Cast(
                movementInput,
                MovementFilter,
                castCollisions,
                MoveSpeed * Time.fixedDeltaTime + CollisionOffset );

            if ( count == 0 )
            {
                characterRigidbody2D.MovePosition( characterRigidbody2D.position + moveDirection *  MoveSpeed * Time.fixedDeltaTime );
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
