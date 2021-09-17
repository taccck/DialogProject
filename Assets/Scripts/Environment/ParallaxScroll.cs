using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    //https://www.youtube.com/watch?v=wBol2xzxCOU&ab_channel=CodeMonkey
    private enum ScrollDir
    {
        X,
        Y,
        Both
    }

    [SerializeField] private ScrollDir scrollDir = ScrollDir.Both;
    [SerializeField] private float effectMulti = 1;
    [SerializeField] private Transform cameraTransform;

    private Vector3 lastCamPos;

    private void LateUpdate()
    {
        //todo only scroll in x dir option and make moon rotate
        Parallaxing();
    }

    private void Parallaxing()
    {
        //moves this with camera relative to the effect multi
        switch (scrollDir)
        {
            case ScrollDir.Both:
                Vector3 currPos = cameraTransform.position;
                Vector3 deltaPos = currPos - lastCamPos;
                transform.position += deltaPos * effectMulti;
                break;

            case ScrollDir.X:
                float currXPos = cameraTransform.position.x;
                float deltaXPos = currXPos - lastCamPos.x;
                transform.position += new Vector3(deltaXPos * effectMulti, 0, 0);
                break;

            case ScrollDir.Y:
                float currYPos = cameraTransform.position.y;
                float deltaYPos = currYPos - lastCamPos.y;
                transform.position += new Vector3(0, deltaYPos * effectMulti, 0);
                break;
        }

        lastCamPos = cameraTransform.position;
    }

    private void Awake()
    {
        lastCamPos = cameraTransform.position;
    }
}