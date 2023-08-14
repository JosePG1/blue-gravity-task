using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed ;
    public float CollisionOffset ;
    public ContactFilter2D MovementFilter;
    
    Vector2 movementInput;
    Rigidbody2D characterRigidbody2D;
    readonly List<RaycastHit2D> castCollisions = new();

    void Start()
    {
        characterRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ( movementInput != Vector2.zero )
        {
            var count = characterRigidbody2D.Cast(
                movementInput,
                MovementFilter,
                castCollisions,
                MoveSpeed * Time.fixedDeltaTime + CollisionOffset );

            if ( count == 0 )
            {
                characterRigidbody2D.MovePosition( characterRigidbody2D.position + movementInput *  MoveSpeed * Time.fixedDeltaTime );
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
