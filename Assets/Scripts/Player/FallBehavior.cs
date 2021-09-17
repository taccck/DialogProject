using UnityEngine;

public class FallBehavior : StateMachineBehaviour
{
    private PlayerAnimationController animController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animController = animator.GetComponent<PlayerAnimationController>();
        animController.Falling = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animController.Falling = false;
    }
}