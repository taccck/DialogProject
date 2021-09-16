using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color unselected;
    [SerializeField] private Color selected;

    private SpawnQuestList qList;
    private QuestManager.QuestInfo questInfo;
    private TextMeshProUGUI tmp;
    private Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        qList.SetSelected(this);
    }

    public void SetUI(QuestManager.QuestInfo qInfo, SpawnQuestList questList)
    {
        questInfo = qInfo;
        tmp.text = qInfo.Name;
        qList = questList;
    }

    public void SetUIFirst(QuestManager.QuestInfo qInfo, SpawnQuestList questList)
    {
        questInfo = qInfo;
        tmp.text = qInfo.Name;
        qList = questList;
        Select();
    }

    public void Select()
    {
        qList.SetMainQuest(questInfo);
        image.color = selected;
    }

    public void UnSelect()
    {
        image.color = unselected;
    }

    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
    }
}