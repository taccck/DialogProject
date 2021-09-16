using TMPro;
using UnityEngine;

public class SpawnQuestList : MonoBehaviour
{
    [SerializeField] private GameObject questUIPrefab;
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
                selected = Instantiate(questUIPrefab, transform).GetComponent<QuestUI>();
                selected.SetUIFirst(quest, this);
                first = false;
            }

            Instantiate(questUIPrefab, transform).GetComponent<QuestUI>().SetUI(quest, this);
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
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t == transform) continue;
            Destroy(t.gameObject);
        }
    }
}