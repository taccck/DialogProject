using UnityEngine;
using UnityEngine.InputSystem;

public class WorldInteractions : MonoBehaviour
{
    [SerializeField] private LayerMask interactMask;
    private Interactable interactable;

    private void OnInteract()
    {
        if (interactable != null)
            interactable.Interact();
    }

    private void OnScroll(InputValue value)
    {
        if (interactable != null)
            interactable.Scroll(value.Get<float>());
    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, .2f, interactMask);
        if (hit == null)
        {
            if (interactable != null)
            {
                interactable.SetInactive();
                interactable = null;
            }

            return;
        }

        interactable = hit.GetComponent<Interactable>();
        if (!interactable.Active)
            interactable.SetActive();
    }
}