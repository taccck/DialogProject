using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ConversationUI : MonoBehaviour
{
    [NonSerialized] public int SelectedIndex;
    [NonSerialized] public string[] OptionText = Array.Empty<string>();
    [NonSerialized] public bool textRolling = false;

    [SerializeField] private TextMeshProUGUI lineText;
    [SerializeField] private GameObject optionPrefab;
    [SerializeField] private Transform optionsList;

    private DialogOptionUI[] dialogButts;
    private DialogOptionUI selected;
    private Coroutine textRoll;
    private string dialogLine;

    public void SetUI(string line, string[] options)
    {
        StartRoll(line);
        OptionText = options;
        dialogButts = new DialogOptionUI[options.Length];
        for (int i = 0; i < options.Length; i++)
        {
            dialogButts[i] = Instantiate(optionPrefab, optionsList).GetComponent<DialogOptionUI>();
            dialogButts[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i];
        }

        UpdateSelected();
    }

    public void SetUI(string line)
    {
        OptionText = Array.Empty<string>();
        StartRoll(line);
    }

    private void StartRoll(string line)
    {
        dialogLine = line;
        if (textRoll != null)
            StopCoroutine(textRoll);

        textRolling = true;
        textRoll = StartCoroutine(TextRoll(line));
    }

    public string GetSelected()
    {
        return OptionText[SelectedIndex];
    }

    public void Remove()
    {
        OptionText = Array.Empty<string>();
        selected = null;
        foreach (Transform t in optionsList.GetComponentsInChildren<Transform>())
        {
            if (t == optionsList.transform) continue;
            Destroy(t.gameObject);
        }
    }

    public void UpdateSelected()
    {
        if (selected != null)
        {
            selected.SetUnselected();
        }

        selected = dialogButts[SelectedIndex];
        selected.SetSelected();
    }

    //todo take more parameters for speed and effect
    private IEnumerator TextRoll(string line)
    {
        string currLine = "";
        foreach (char s in line)
        {
            currLine += s;
            lineText.text = currLine;
            
            if (s == ' ')
                continue;

            yield return new WaitForSeconds(.1f);
        }

        textRolling = false;
    }

    public void SkipTextRoll()
    {
        if (textRoll != null)
            StopCoroutine(textRoll);
        textRolling = false;

        lineText.text = dialogLine;
    }
}