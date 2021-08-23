using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovmentController : MonoBehaviour
{
    private PlayerInput _controls;
    
    [NonSerialized] public bool Walking;

    [SerializeField, Tooltip("Meters / second")] private float walkSpeed = 5f;
    
    private Rigidbody2D _body;

    private void Update()
    {
        GetComponentInChildren<Animator>().SetBool("Walking", Walking);
    }

    public void Walk(InputAction.CallbackContext value)
    {
        int direction = (int) Mathf.Clamp(value.ReadValue<float>(), -1f, 1f);
        Walking = (direction != 0);
        _body.velocity = new Vector2(direction * walkSpeed, _body.velocity.y);
        Flip(direction);
    }

    private void Flip(int direction)
    {
        if ( direction == 0) 
        {return;}
        
        transform.localScale = new Vector2(direction, 1);
    }

    private void Awake()
    {
        _body = GetComponentInParent<Rigidbody2D>();
        _controls = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _controls.actions.Enable();
    }

    private void OnDisable()
    {
        _controls.actions.Disable();
    }
}