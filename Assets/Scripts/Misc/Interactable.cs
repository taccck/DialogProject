using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [NonSerialized] public bool Active = false;
    [SerializeField] private GameObject activeGO;
    public virtual void Interact()
    {
        activeGO.SetActive(false);
    }
    
    public virtual void SetActive()
    {
        Active = true;
        activeGO.SetActive(true);
    }
    
    public virtual void SetInactive()
    {
        Active = false;
        activeGO.SetActive(false);
    }

    public virtual void Scroll(float direction)
    {
        
    }
}