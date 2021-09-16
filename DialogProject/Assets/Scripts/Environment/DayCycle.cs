using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1f;

    private void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
    }
}