using TMPro;
using UnityEngine;

public class SpawnQuestList : MonoBehaviour
{
    [SerializeField] private GameObject questUIPrefab;
    [SerializeField] private Transform questListParent;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private TextMeshProUGUI qName;
    [SerializeField] private TextMeshProUGUI qCheckpoint;

    private QuestUI selected;

    public void SpawnQuests()
    {
        bool first = true;
        foreach (QuestManager.QuestInfo quest in questManager.AllUncompletedQuests())
        {
            if (first)
            {
                selected = Instantiate(questUIPrefab, questListParent).GetComponent<QuestUI>();
                selected.SetUIFirst(quest, this);
                first = false;
                continue;
            }

            Instantiate(questUIPrefab, questListParent).GetComponent<QuestUI>().SetUI(quest, this);
        }

        if (first)
        {
            qName.text = "";
            qCheckpoint.text = "No uncompleted quests left";
        }
    }

    public void SetMainQuest(QuestManager.QuestInfo info)
    {
        qName.text = info.Name;
        qCheckpoint.text = info.Checkpoint;
    }

    public void SetSelected(QuestUI q)
    {
        if (selected != null)
            selected.UnSelect();
        selected = q;
        q.Select();
    }

    public void RemoveQuests()
    {
        foreach (Transform t in questListParent.GetComponentsInChildren<Transform>())
        {
            if (t == questListParent) continue;
            Destroy(t.gameObject);
        }
    }
}