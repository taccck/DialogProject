using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1f;
    private Transform sunOrMoon;

    private void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
        sunOrMoon.rotation *= Quaternion.Euler(0, 0, -rotateSpeed);
    }

    private void Awake()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t == transform) continue;
            sunOrMoon = t;
        }
    }
}