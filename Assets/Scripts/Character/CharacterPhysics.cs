using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPhysics : MonoBehaviour
{
    [NonSerialized] public bool ONGround;
    [NonSerialized] public bool IgnoreGravity;

    [SerializeField] private LayerMask groundLayer;
    [Header("Characters dimensions")]
    [SerializeField] private Vector2 charactersCenter;
    [SerializeField] private Vector2 charactersSize;
    
    private const float MAXDistanceToGround = .1f;
    private const float MINGravityScale = -.1f;

    private Rigidbody2D body;
    
    private void FixedUpdate()
    {
        OnGround();
        Gravity();
    }
    
    private void OnGround()
    {
        Vector2 position = transform.position;
        ONGround = Physics2D.BoxCast(charactersCenter + position, charactersSize, 0, Vector2.down,
            MAXDistanceToGround, groundLayer);
    }

    private void Gravity()
    {
        if (IgnoreGravity) return;
        
        if (ONGround)
        {
            body.velocity = new Vector2(body.velocity.x, MINGravityScale); 
            return;
        }

        float currFallSpeed = body.velocity.y + Physics2D.gravity.y * Time.deltaTime;
        body.velocity = new Vector2(body.velocity.x, currFallSpeed);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
}