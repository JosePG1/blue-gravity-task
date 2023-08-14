using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueGravity.World
{
    public class PlayerController : MonoBehaviour
    {
        #region Animator

        // Animation parameter keys
        const string AnimatorHorizontalMovementKey = "isHorizontalMoving";
        const string AnimatorMovingUpKey = "isMovingUp";
        const string AnimatorMovingDownKey = "isMovingDown";

        // Hashes for animation parameters
        static readonly int IsHorizontalMoving = Animator.StringToHash( AnimatorHorizontalMovementKey );
        static readonly int IsMovingUp = Animator.StringToHash( AnimatorMovingUpKey );
        static readonly int IsMovingDown = Animator.StringToHash( AnimatorMovingDownKey );

        #endregion

        [SerializeField] float MoveSpeed;
        [SerializeField] float CollisionOffset;

        [SerializeField] Animator PlayerAnimator;
        [SerializeField] Rigidbody2D CharacterRigidbody2D;
        [SerializeField] SpriteRenderer SpriteRenderer;

        Vector2 movementInput;

        // Contact filter for collision checks
        ContactFilter2D movementFilter;

        // List to store collision information
        readonly List<RaycastHit2D> castCollisions = new();

        void Update()
        {
            // Update animation parameters based on movement input
            PlayerAnimator.SetBool( IsHorizontalMoving, movementInput.x != 0 );
            PlayerAnimator.SetBool( IsMovingUp, movementInput.y > 0 );
            PlayerAnimator.SetBool( IsMovingDown, movementInput.y < 0 );

            // Flip sprite horizontally based on movement direction
            if ( movementInput.x > 0 )
            {
                SpriteRenderer.flipX = false;
            }
            else if ( movementInput.x < 0 )
            {
                SpriteRenderer.flipX = true;
            }

            // Perform movement and collision checks
            if ( movementInput != Vector2.zero )
            {
                var moveDirection = movementInput.normalized;
                var moveAmount = MoveSpeed * Time.fixedDeltaTime;

                // Restrict movement to cardinal directions (up, down, left, right), no diagonals
                // if ( Mathf.Abs( moveDirection.x ) > Mathf.Abs( moveDirection.y ) )
                // {
                //     moveDirection.y = 0;
                // }
                // else
                // {
                //     moveDirection.x = 0;
                // }

                var distance = moveAmount + CollisionOffset;
                // Perform collision checks, to figure out the number of collisions
                var nCollisions = CharacterRigidbody2D.Cast( moveDirection, movementFilter, castCollisions, distance );

                // Move the character if there are no collisions
                if ( nCollisions == 0 )
                {
                    CharacterRigidbody2D.MovePosition( CharacterRigidbody2D.position + moveDirection * moveAmount );
                }
            }
        }

        // Callback for movement input using Input System
        void OnMove( InputValue movementValue )
        {
            movementInput = movementValue.Get<Vector2>();
        }
    }
}