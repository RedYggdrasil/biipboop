using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    private static UIInGame _instance;
    public static UIInGame instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;
    [SerializeField] private Image _image1Top;
    [SerializeField] private Image _image2Top;
    [SerializeField] private Sprite _circle;
    [SerializeField] private Sprite _cross;


    [SerializeField] private SpriteContainer[] _sprites;

    public void OnEnterStep(int stepIndex, BotObject part)
    {
        StartCoroutine(OnUiChange(stepIndex, part));
    }
    private IEnumerator OnUiChange(int stepIndex, BotObject part)
    {
        if (stepIndex > 0)
        {
            bool first = (part == _sprites[stepIndex - 1].part1);
            Image round = ((first)?_image1Top:_image2Top);
            Image Cross = ((first)?_image2Top:_image1Top);
            round.color = new Color(1f, 1f, 1f, 1f);
            Cross.color = new Color(1f, 1f, 1f, 1f);
            round.sprite = _circle;
            Cross.sprite = _cross;
            yield return new WaitForSeconds(2f);
            round.color = new Color(1f, 1f, 1f, 0f);
            Cross.color = new Color(1f, 1f, 1f, 0f);
        }
        _image1.sprite = _sprites[stepIndex].sprite1;
        _image2.sprite = _sprites[stepIndex].sprite2;
    }
}

[System.Serializable]
public class SpriteContainer
{
    public Sprite sprite1;
    public BotObject part1;
    public Sprite sprite2;
    public BotObject part2;
}