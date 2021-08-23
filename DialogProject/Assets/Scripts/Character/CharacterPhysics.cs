using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPhysics : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [Header("Characters dimensions")]
    [SerializeField] private Vector2 charactersCenter;
    [SerializeField] private Vector2 charactersSize;
    
    private const float MAXDistanceToGround = .1f;
    
    private bool _onGround;
    private Rigidbody2D _body;
    
    private void FixedUpdate()
    {
        OnGround();

        Gravity();
    }
    
    private void OnGround()
    {
        _onGround = Physics2D.BoxCast(charactersCenter, charactersSize, 0, Vector2.down, MAXDistanceToGround,
            groundLayer);
    }

    private void Gravity()
    {
        if (_onGround)
        {
            _body.velocity = new Vector2(_body.velocity.x, .1f);
            return;
        }

        float currFallSpeed = _body.velocity.y + (Physics2D.gravity.y * Time.deltaTime);
        _body.velocity = new Vector2(_body.velocity.x, currFallSpeed);
    }

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
}