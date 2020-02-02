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
    //public Color passiveHighlightColor;

    public float highlightStrength;

    private Color initialMatColor;
    private void Start()
    {
        initialMatColor = highlightRenderer.material.color;
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
        highlightActivated = true;
        float t = 0;
        while (t < HighlightTime & highlightActivated)
        {
            yield return new WaitForSeconds(0.05f);
            t += 0.05f;
            Color newColor = highlightRenderer.material.color;
            if (t <= HighlightTime / 2)
            {
                newColor.b += highlightStrength;
                newColor.g += highlightStrength;
                newColor.r += highlightStrength;
            } else
            {
                newColor.b -= highlightStrength;
                newColor.g -= highlightStrength;
                newColor.r -= highlightStrength;
            }
            highlightRenderer.material.color = newColor;
        }
        highlightRenderer.material.color = initialMatColor;
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
