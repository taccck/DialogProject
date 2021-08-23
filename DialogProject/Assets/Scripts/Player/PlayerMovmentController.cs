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
    private float maxJumpTime = 5f;
    [SerializeField, Tooltip("Meters / second")]
    private float _jumpSpeed;

    private Rigidbody2D _body;
    private PlayerInput _controls;
    private CharacterPhysics _characterPhysics;
    private int _walkDir;
    private bool _jumpInput;
    private float _currJumpTime;

    private void FixedUpdate()
    {
        GetComponentInChildren<Animator>().SetBool("Walking", Walking);

        Walk();
        Jump();
    }

    private void OnMove(InputValue value) => _walkDir = (int) value.Get<float>();

    private void OnJump(InputValue value)
    {
        print(_characterPhysics.ONGround);
        if (value.isPressed && _characterPhysics.ONGround)
        {
            print("jklfdjklfgds");
        }

    } 

    public void Walk()
    {
        Walking = _walkDir != 0;
        _body.velocity = _body.velocity.SetX(_walkDir * walkSpeed); //todo fix this
        Flip();
    }

    private void Flip()
    {
        if (_walkDir == 0) return;
        transform.localScale = transform.localScale.SetX(_walkDir);
    }
    
    private void Jump()
    {
        _characterPhysics.IgnorGravity = false;
        if (!Jumping)
        {
            _currJumpTime = 0;
            Jumping = false;
            return;
        }
        
        _currJumpTime += Time.deltaTime;
        if (_currJumpTime >= maxJumpTime)
        {
            _currJumpTime = 0;
            Jumping = false;
            return;
        }

        _characterPhysics.IgnorGravity = true;
        _body.velocity = _body.velocity.SetY(_jumpSpeed);
    }

    private void Awake()
    {
        _body = GetComponentInParent<Rigidbody2D>();
        _controls = GetComponent<PlayerInput>();
        _characterPhysics = GetComponent<CharacterPhysics>();
    }

    private void OnEnable() => _controls.actions.Enable();

    private void OnDisable() => _controls.actions.Disable();
}