using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(CharacterPhysics))]
public class PlayerMovmentController : MonoBehaviour
{
    [NonSerialized] public bool Walking;
    [NonSerialized] public bool Jumping;

    [SerializeField, Tooltip("Meters / second"), Header("Walking")]
    private float walkSpeed = 5f;
    [SerializeField, Tooltip("Seconds"), Header("Jumping")]
    private float maxJumpTime = .5f;
    [SerializeField, Tooltip("Meters / second")]
    private float jumpSpeed = 7f;

    private Rigidbody2D body;
    private PlayerInput controls;
    private CharacterPhysics characterPhysics;
    private PlayerAnimationController animController;
    private int walkDir;
    private float currJumpTime;

    private void FixedUpdate()
    {
        Animate();
        Walk();
        Jump();
    }

    private void Animate()
    {
        if (Jumping)
            animController.ChangeAnimationState(animController.Jump);
        else if (!characterPhysics.ONGround)
            animController.ChangeAnimationState(animController.Fall);
        else if(Walking)
            animController.ChangeAnimationState(animController.Walk);
        else 
            animController.ChangeAnimationState(animController.Idle);
    }

    private void OnMove(InputValue value) => walkDir = (int)value.Get<float>();

    private void OnJump(InputValue value)
    {
        if (value.isPressed && characterPhysics.ONGround)
        {
            Jumping = true;
            return;
        }

        Jumping = false;
    }

    private void Walk()
    {
        Walking = walkDir != 0;
        body.velocity = new Vector2(walkDir * walkSpeed, body.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (walkDir == 0) return;
        transform.localScale = new Vector2(walkDir, transform.localScale.y);
    }
    
    private void Jump()
    {
        characterPhysics.IgnoreGravity = false;
        currJumpTime += Time.deltaTime;
        if (!Jumping || currJumpTime >= maxJumpTime)
        {
            currJumpTime = 0;
            Jumping = false;
            return;
        }

        characterPhysics.IgnoreGravity = true;
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    private void Awake()
    {
        body = GetComponentInParent<Rigidbody2D>();
        controls = GetComponent<PlayerInput>();
        characterPhysics = GetComponent<CharacterPhysics>();
        animController = GetComponentInChildren<PlayerAnimationController>();
    }

    private void OnEnable() => controls.actions.Enable();

    private void OnDisable() => controls.actions.Disable();
}