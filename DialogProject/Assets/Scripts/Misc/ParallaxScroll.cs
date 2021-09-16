using UnityEngine;

public class ParallaxScroll : MonoBehaviour 
{
    //https://www.youtube.com/watch?v=wBol2xzxCOU&ab_channel=CodeMonkey
    [SerializeField] private float effectMulti = 1;
    [SerializeField] private Transform cameraTransform;
    
    private Vector3 lastCamPos;

    private void LateUpdate()
    {
        Parallaxing();
    }

    private void Parallaxing()
    {
        //moves this with camera relative to the effect multi
        Vector3 currPos = cameraTransform.position;
        Vector3 deltaPos = currPos - lastCamPos;
        transform.position += deltaPos * effectMulti;
        lastCamPos = currPos;
    }
    
    private void Awake()
    {
        lastCamPos = cameraTransform.position;
    }
}
