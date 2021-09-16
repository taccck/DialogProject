using UnityEngine;

public class NPCQuestManger : MonoBehaviour 
{
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
}
