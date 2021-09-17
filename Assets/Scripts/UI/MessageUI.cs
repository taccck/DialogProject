using System.Collections;
using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    private TextMeshProUGUI message;

    public void SetMessage(string toDisplay)
    {
        message.text = toDisplay + "\n" + "Q";
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            message.color = new Color(message.color.r, message.color.g, message.color.b, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            message.color = new Color(message.color.r, message.color.g, message.color.b, alpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void Awake()
    {
        message = GetComponentInChildren<TextMeshProUGUI>();
    }
}