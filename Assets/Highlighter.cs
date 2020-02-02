using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Renderer highlightRenderer;
    public float HighlightTime;
    //public Color activeHighlightColor;
    public bool highlightActivated = true;
    public bool hasPassiveHighlight;
    public float passiveHighlightPeriod;
    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color highlightColor = Color.grey;
    //public Color passiveHighlightColor;

    public float highlightStrength;

    private void Start()
    {
        if (hasPassiveHighlight)
        {
            activatePassiveHighlight();
        }
    }

    public void ActiveHighlightTrigger()
    {
        highlightActivated = false;
        hasPassiveHighlight = false;
        StartCoroutine(ActiveHighlight(0.5f));
    }

    public void activatePassiveHighlight()
    {
        if (!hasPassiveHighlight)
        {
            hasPassiveHighlight = true;
        }
        StartCoroutine(PassiveHighlight());
    }

    IEnumerator ActiveHighlight(float delay)
    {
        yield return new WaitForSeconds(delay);


        float startTime = Time.time;
        float halfTime = Time.time + HighlightTime * 0.5f;
        float endTime = Time.time + HighlightTime;
        while (Time.time < halfTime)
        {
            highlightRenderer.material.color = Color.Lerp(normalColor, highlightColor, (Time.time - startTime) / (HighlightTime * 0.5f));
            yield return null;
        }
        while (Time.time < endTime)
        {
            highlightRenderer.material.color = Color.Lerp(highlightColor, normalColor, (Time.time - halfTime) / (HighlightTime * 0.5f));
            yield return null;
        }
        highlightRenderer.material.color = normalColor;
        yield break;
    }

    IEnumerator PassiveHighlight()
    {
        hasPassiveHighlight = true;
        while (hasPassiveHighlight)
        {
            yield return new WaitForSeconds(passiveHighlightPeriod);
            yield return ActiveHighlight(0f);
        }
        yield break;
    }
}
