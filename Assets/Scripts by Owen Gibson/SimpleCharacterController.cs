using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    /// <summary>
    /// This class holds all the variables and functionality for moving our character around our game world.
    /// </summary>
    public class SimpleCharacterController : MonoBehaviour
    {
        private float horizontalInputValue; // The value of our horizontal input axis.
        private SpriteRenderer spriteRenderer; // Our character's sprite.
        private LayerMask groundLayerMask;
        private bool isGrounded = false;

        // TODO Movement 1/8: Declare a variable for a reference to our 2D rigidbody, for physics stuff.
        private Rigidbody2D rbody2D;
        // TODO Movement 2/8: Declare a variable for the speed we can run at in Unity-units-per-second.
        public float runSpeed = 3f;
        // TODO Movement 3/8: Declare a variable for the strength of our jump.
        public float jumpStrength = 1f;

        private void Start()
        {
            rbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
            groundLayerMask = LayerMask.GetMask("Ground");

        }
        private void Update()
        {
            // TODO Movement 4/8: Store our horizontal player input value so we can access it later on.
            horizontalInputValue = Input.GetAxisRaw("Horizontal");
            // TODO Movement 5/8: Transform our character's position on the X axis. (Reference our stored horizontal input value here!)
            transform.position += new Vector3(horizontalInputValue, 0, 0) * runSpeed * Time.deltaTime;
            
            // TODO Movement 6/8: Check if the player presses the "Jump" button (by default, the space bar on the keyboard).
             if (Input.GetButtonDown("Jump") && isGrounded)
            {
                isGrounded = false;
                // TODO Movement 7/8: If they do, then add vertical velocity to our rigidbody to make our character "jump"!
                rbody2D.velocity = new Vector3(rbody2D.velocity.x, jumpStrength);

            }
            
           
            // TODO Movement 8/8: Add this script to a game object and make a new prefab from it, and explore the level!
                // done
            // TODO Movement Final: Add code comments describing what you hope your code is doing throughout this script.
                // This code makes the character move when the correct keys are pressed.
                // It also lets the character jump but only when the character is already on the ground
            // TODO Movement Bonus 1: Ensure that our character can only jump if they are "grounded". (Hint: You can use a boolean as a part of this!)
                // done 😁
            // TODO Movement Bonus 2: Flip our character's sprite so that it faces left/right if we are moving left/right. (Hint: A SpriteRenderer reference, and changing its FlipX = true/false will help!)
            if (horizontalInputValue == 1)
            {
                spriteRenderer.flipX = true;
            }
            if (horizontalInputValue == -1)
            {
                spriteRenderer.flipX = false;
            }
        }

        private void FixedUpdate() {
            // Checking if the player is on the ground
            if (Physics2D.OverlapCircle(transform.position, 0.1f, groundLayerMask)) {
                isGrounded = true;
            }
            else {
                isGrounded = false;
            }
        }
    }
}
