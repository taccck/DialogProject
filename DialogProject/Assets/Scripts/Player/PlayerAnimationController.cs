using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public readonly int Idle = Animator.StringToHash("Idle");
    public readonly int Walk = Animator.StringToHash("Walk");
    public readonly int Jump = Animator.StringToHash("Jump");
    public readonly int Fall = Animator.StringToHash("Fall");

    [NonSerialized] public bool Falling;

    private Animator animator;
    private Rigidbody2D body;
    private int currState;

    private const float StretchSpeed = .5f;

    public void ChangeAnimationState(int newState)
    {
        if (currState == newState)
            return;

        animator.Play(newState);
        currState = newState;
    }

    private void LateUpdate()
    {
        if (Falling)
            FallAnim();
    }

    private void FallAnim()
    {
        float yScale = Mathf.Abs(body.velocity.y / (Physics.gravity.y * 1.5f)) + .5f;
        yScale = Mathf.Lerp(transform.localScale.y, yScale, StretchSpeed);

        transform.localScale = new Vector3(1, yScale, 1);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponentInParent<Rigidbody2D>();
    }
}