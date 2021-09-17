using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Quest startQuest;
    [SerializeField] private SpawnQuestList questList;
    [SerializeField] private MessageUI messageUI;
    
    private Stack<Quest> quests = new Stack<Quest>(); 
    private bool menuOpen;

    private void OnQuest()
    {
        menuOpen = !menuOpen;
        questList.gameObject.SetActive(menuOpen);

        if (menuOpen)
        {
            questList.SpawnQuests();
            Time.timeScale = 0;
        }
        else
        {
            questList.RemoveQuests();
            Time.timeScale = 1;
        }
    }

    public void Add(Quest q)
    {
        messageUI.SetMessage(q.GetCheckpoint());
        quests.Push(q);
    }

    public QuestInfo[] AllUncompletedQuests()
    {
        List<QuestInfo> questInfos = new List<QuestInfo>();
        foreach (Quest t in quests)
        {
            if (!t.Completed)
                questInfos.Add(new QuestInfo()
                {
                    Name = t.name,
                    Checkpoint = t.GetCheckpoint()
                });
        }

        return questInfos.ToArray();
    }

    public QuestInfo[] AllCompletedQuests()
    {
        List<QuestInfo> questInfos = new List<QuestInfo>();
        foreach (Quest t in quests)
        {
            if (t.Completed)
                questInfos.Add(new QuestInfo()
                {
                    Name = t.name,
                    Checkpoint = t.GetCheckpoint()
                });
        }

        return questInfos.ToArray();
    }

    public struct QuestInfo
    {
        public string Name;
        public string Checkpoint;
    }

    private void Start()
    {
        startQuest.Reset();
        Add(startQuest);
    }
}