using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] private Transform toFollow;
    [SerializeField] private float speed = .75f;

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(toFollow.position, transform.position, speed);
        //transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}