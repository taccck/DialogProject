using System.Collections;
using UnityEngine;

public class NPCQuestManger : MonoBehaviour
{
    [SerializeField] private MessageUI messageUI;
    
    public bool CompareStates(Quest q, int intState)
    {
        return intState == q.GetState();
    }

    public bool CompareStates(Quest q, string stringState)
    {
        return q.GetCheckpoint() == stringState;
    }
    
    public bool CheckQuestCompleted(Quest quest)
    {
        return quest.Completed;
    } 

    public void IncreaseQuestState(Quest q)
    {
        q.IncrementState();
        messageUI.SetMessage(q.GetCheckpoint());
    }
    
    public void DecreaseQuestState(Quest q)
    {
        q.ReduceState();
        messageUI.SetMessage(q.GetCheckpoint());
    }
}
