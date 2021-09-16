using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest startQuest;
    
    [SerializeField] private GameObject questCanvas;
    
    private SpawnQuestList qList;
    public List<Quest> quests = new List<Quest>(); //todo add completed quest list
    private bool menuOpen;

    private void OnQuest()
    {
        menuOpen = !menuOpen;
        questCanvas.SetActive(menuOpen);

        if (menuOpen)
        {
            qList.SpawnQuests();
            Time.timeScale = 0;
        }
        else
        {
            qList.RemoveQuests();
            Time.timeScale = 1;
        }
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

    private void Awake()
    {
        qList = questCanvas.GetComponentInChildren<SpawnQuestList>();
        quests.Add(startQuest);
    }
}