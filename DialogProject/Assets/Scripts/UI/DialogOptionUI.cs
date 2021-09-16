using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DialogOptionUI : MonoBehaviour
{
    [SerializeField] private Color unselected;
    [SerializeField] private Color selected;
    private Image image;

    public void SetSelected()
    {
        image.color = selected;
    }

    public void SetUnselected()
    {
        image.color = unselected;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }
}
