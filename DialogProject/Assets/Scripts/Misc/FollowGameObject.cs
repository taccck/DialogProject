using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] private Transform toFollow;
    [SerializeField] private float smoothing = .75f;
    [SerializeField] private bool fixedX;

    private void FixedUpdate()
    {
        if (fixedX)
        {
            transform.position = new Vector3(toFollow.position.x, transform.position.y, transform.position.z);
            return;
        }
        
        transform.position = Vector2.Lerp(toFollow.position, transform.position, smoothing);
    }
}