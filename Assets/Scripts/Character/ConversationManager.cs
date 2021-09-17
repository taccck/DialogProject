using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class ConversationManager : Interactable
{
    [SerializeField] private ConversationUI conversationUI;

    private List<string> dialogStates = new List<string>();
    private int dialogStateIndex;
    private int stateIndex = 1;
    private string startState = "Start";

    public bool DialogWithResponse(string line, string[] options, int dialogCount)
    {
        if (stateIndex == dialogCount) //correct state found
        {
            dialogStateIndex = 0;
            stateIndex++;
            conversationUI.Remove();
            conversationUI.gameObject.SetActive(true);
            conversationUI.SetUI(line, options);
            return false;
        }

        //return true when flow graph should keep going
        return true;
    }

    public bool Dialog(string line, int dialogCount)
    {
        if (stateIndex == dialogCount)
        {
            dialogStateIndex = 0;
            stateIndex++;
            conversationUI.Remove();
            conversationUI.gameObject.SetActive(true);
            conversationUI.SetUI(line);
            return false;
        }
        
        return true;
    }

    public void EndConversation()
    {
        dialogStates = new List<string>();
        stateIndex = 1;
        dialogStateIndex = 0;
    }

    public void EndConversation(string newStart)
    {
        startState = newStart;
        dialogStates = new List<string>();
        stateIndex = 1;
        dialogStateIndex = 0;
    }

    public override void Interact()
    {
        if (conversationUI.textRolling)
        {
            conversationUI.SkipTextRoll();
            return;
        }

        base.Interact();
        
        //if options are displayed, add one as a state
        if (conversationUI.OptionText.Length > 0)
        {
            dialogStates.Add(conversationUI.GetSelected());
        }

        CustomEvent.Trigger(gameObject, "HaveConversation");
    }

    public override void Scroll(float direction)
    {
        direction *= -1;
        if (conversationUI.OptionText.Length > 0)
        {
            int directionInt = Mathf.RoundToInt(direction);
            conversationUI.SelectedIndex += directionInt;
            conversationUI.SelectedIndex =
                Mathf.Clamp(conversationUI.SelectedIndex, 0, conversationUI.OptionText.Length - 1);
            conversationUI.UpdateSelected();
        }
    }

    public string GetDialogState()
    {
        string currState = dialogStates[dialogStateIndex];
        dialogStateIndex++;
        return currState;
    }

    public override void SetInactive()
    {
        EndConversation();
        Reset();
        base.SetInactive();
    }

    public void Reset()
    {
        conversationUI.Remove();
        conversationUI.gameObject.SetActive(false);
        dialogStates.Add(startState);
        base.SetActive();
    }

    public bool ShouldReset()
    {
        return dialogStates.Count == 0;
    }

    private void Awake()
    {
        dialogStates.Add(startState);
    }
}